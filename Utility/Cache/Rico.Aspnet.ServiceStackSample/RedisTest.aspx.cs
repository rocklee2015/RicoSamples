using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.Aspnet.ServiceStackSample
{
    public partial class RedisTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOpenDB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"E:\rico-demo\Redis\redis-2.4.5-win32-win64\64bit\redis-server.exe");//此处为Redis的存储路径
            lblShow.Text = "Redis已经打开！";

            using (var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();

                if (user.GetAll().Count > 0)
                    user.DeleteAll();

                var qiujialong = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "qiujialong",
                    Job = new Job { Position = ".NET" }
                };
                var chenxingxing = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "chenxingxing",
                    Job = new Job { Position = ".NET" }
                };
                var luwei = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "luwei",
                    Job = new Job { Position = ".NET" }
                };
                var zhourui = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "zhourui",
                    Job = new Job { Position = "Java" }
                };

                var userToStore = new List<User> { qiujialong, chenxingxing, luwei, zhourui };
                user.StoreAll(userToStore);

                Thread.Sleep(3000);

                lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
            }
        }

        protected void btnSetValue_Click(object sender, EventArgs e)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();
                if (user.GetAll().Count > 0)
                {
                    var htmlStr = user.GetAll().Aggregate(string.Empty, (current, u) => current + ("<li>ID=" + u.Id + "&nbsp;&nbsp;姓名：" + u.Name + "&nbsp;&nbsp;所在部门：" + u.Job.Position + "</li>"));
                    lblPeople.Text = htmlStr;
                }
                lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
            }
        }
        protected void btnSetValueALL_Click(object sender, EventArgs e)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();
                var userKeyList = user.GetAllKeys();
                if (user.GetAll().Count > 0)
                {
                    var htmlStr = string.Empty;
                    foreach (var key in userKeyList)
                    {
                        htmlStr += "<li>key=" + key + "</li>";
                    }
                    lblPeople.Text = htmlStr;
                }
                lblShow.Text = "共有：" + userKeyList.Count.ToString() + "Keys！";
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPosition.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var user = redisClient.GetTypedClient<User>();

                    var newUser = new User
                    {
                        Id = user.GetNextSequence(),
                        Name = txtName.Text,
                        Job = new Job { Position = txtPosition.Text }
                    };
                    var userList = new List<User> { newUser };
                    user.StoreAll(userList);

                    if (user.GetAll().Count > 0)
                    {
                        var htmlStr = string.Empty;
                        foreach (var u in user.GetAll())
                        {
                            htmlStr += "<li>ID=" + u.Id + "&nbsp;&nbsp;姓名：" + u.Name + "&nbsp;&nbsp;所在部门：" + u.Job.Position + "</li>";
                        }
                        lblPeople.Text = htmlStr;
                    }
                    lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
                }
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRedisId.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var user = redisClient.GetTypedClient<User>();
                    user.DeleteById(txtRedisId.Text);

                    if (user.GetAll().Count > 0)
                    {
                        var htmlStr = string.Empty;
                        foreach (var u in user.GetAll())
                        {
                            htmlStr += "<li>ID=" + u.Id + "&nbsp;&nbsp;姓名：" + u.Name + "&nbsp;&nbsp;所在部门：" + u.Job.Position + "</li>";
                        }
                        lblPeople.Text = htmlStr;
                    }
                    lblShow.Text = "目前共有：" + user.GetAll().Count.ToString() + "人！";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScreenPosition.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var user = redisClient.GetTypedClient<User>();
                    var userList = user.GetAll().Where(x => x.Job.Position.Contains(txtScreenPosition.Text)).ToList();

                    if (userList.Count > 0)
                    {
                        var htmlStr = string.Empty;
                        foreach (var u in userList)
                        {
                            htmlStr += "<li>ID=" + u.Id + "&nbsp;&nbsp;姓名：" + u.Name + "&nbsp;&nbsp;所在部门：" + u.Job.Position + "</li>";
                        }
                        lblPeople.Text = htmlStr;
                    }
                    lblShow.Text = "筛选后共有：" + userList.Count.ToString() + "人！";
                }
            }
        }
        protected void btnSearchByKey_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKey.Text))
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var keyValue = string.Empty;
                    try
                    {
                        var user = redisClient.GetTypedClient<User>();
                        var value = user.GetValue(txtKey.Text);
                        keyValue += "ID=" + value.Id + "&nbsp;&nbsp;姓名：" + value.Name + "&nbsp;&nbsp;所在部门：" + value.Job.Position;
                    }
                    catch (Exception ex)
                    {
                        keyValue += ex.ToString();
                    }
                    lblPeople.Text = keyValue.ToJson();
                    lblShow.Text = string.Empty;
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();
                var value = user.GetValue(txtChangeKey.Text);//首先先获取当前key的值
                var changedUser = new User
                {
                    Id = value.Id,
                    Name = txtChangeName.Text,
                    Job = new Job { Position = txtChangePosition.Text }
                };//设置相应的新value值，并使其它数据与原来相统一
                redisClient.Set(txtChangeKey.Text, changedUser);//修改value
                value = user.GetValue(txtChangeKey.Text);//根据key获取最新的数据

                var htmlStr = string.Empty;
                htmlStr += "修改后的ID=" + value.Id + "&nbsp;&nbsp;姓名：" + value.Name + "&nbsp;&nbsp;所在部门：" + value.Job.Position;
                lblPeople.Text = htmlStr;
                lblShow.Text = "筛选后共有：1人！";

            }
        }
        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            var dictionary = new Dictionary<string, User>();
            using (var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();
                var user1 = new User
                {
                    Id = user.GetNextSequence(),//获取新的ID
                    Name = "小明",
                    Job = new Job { Position = "Python" }
                };
                var user2 = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "小红",
                    Job = new Job { Position = "Python" }
                };
                var userKeyList = user.GetAllKeys().Where(x => x.StartsWith("urn")).OrderBy(y => y).ToList();//只获取保存value的key
                dictionary.Add(userKeyList[1], user1);//第二个人
                dictionary.Add(userKeyList[2], user2);//第三个人
                redisClient.SetAll(dictionary);//同时修改多个value

                var users = user.GetAll();
                if (users.Count > 0)
                {
                    var htmlStr = string.Empty;
                    foreach (var u in users)
                    {
                        htmlStr += "<li>ID=" + u.Id + "&nbsp;&nbsp;姓名：" + u.Name + "&nbsp;&nbsp;所在部门：" + u.Job.Position + "</li>";
                    }
                    lblPeople.Text = htmlStr;
                }
                lblShow.Text = "筛选后共有：" + users.Count.ToString() + "人！";
            }
        }
        protected void btnRenameKey_Click(object sender, EventArgs e)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.RenameKey(txtKey.Text, txtNewKey.Text);

                var user = redisClient.GetTypedClient<User>();
                var userKeyList = user.GetAllKeys();

                if (userKeyList.Count > 0)
                {
                    lblPeople.Text = string.Empty;
                    var htmlStr = string.Empty;
                    foreach (var u in userKeyList)
                    {
                        htmlStr += "<li>key=" + u + "</li>";
                    }
                    lblPeople.Text = htmlStr;
                }
                lblShow.Text = "筛选后共有：" + userKeyList.Count.ToString() + " Keys！";
            }
        }
    }
}