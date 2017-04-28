using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.Csharp.Samples
{
    [TestClass]
    public class S02MultiInheritInterface
    {
        [TestMethod]
        public void Interface_Test()
        {
            ICommand icommand = new UpdatePhoneCommand
            {
                CommandId = Guid.NewGuid().ToString(),
                Lat = "21.44",
                Lng = "42.22",
                SiUserId = "ssss"
            };
            var lngAndLat = (IOperateLoactionCommand)icommand;
            Assert.AreEqual(lngAndLat.Lng, "42.22");
            //var siCommand = (ISiCommand)icommand;
            //Assert.AreEqual(siCommand.SiUserId, "ssss");
        }
    }

    public interface ICommand
    {
        string CommandId { get; set; }
    }

    public interface ISiCommand:ICommand
    {
        string SiUserId { get; set; }

    }
    /// <summary>
    /// 操作定位command
    /// </summary>
    public interface IOperateLoactionCommand
    {
        /// <summary>
        /// 经度
        /// </summary>
        string Lng { get; set; }
        /// <summary>
        /// 维度
        /// </summary>
        string Lat { get; set; }
    }

    public interface IOperateLoactionCommand2
    {
        /// <summary>
        /// 经度
        /// </summary>
        string Lng { get; set; }
        /// <summary>
        /// 维度
        /// </summary>
        string Lat { get; set; }
    }

    public class Command
    {

    }

    public class UpdatePhoneCommand : ISiCommand, IOperateLoactionCommand
    {
        #region Implementation of ISiCommand

        public string SiUserId { get; set; }

        #endregion

        #region Implementation of ILngAndLatCommand

        public string Lng { get; set; }
        public string Lat { get; set; }

        #endregion

        #region Implementation of ICommand

        public string CommandId { get; set; }

        #endregion
    }
}
