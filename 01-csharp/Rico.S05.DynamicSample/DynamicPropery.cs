namespace Rico.S05.DynamicSample
{
    /// <summary>
    /// 动态添加属性
    /// </summary>
    class DynamicPropery : System.Dynamic.DynamicObject
    {
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            if (map != null)
            {
                string name = binder.Name;
                object value;
                if (map.TryGetValue(name, out value))
                {
                    result = value;
                    return true;
                }
            }
            return base.TryGetMember(binder, out result);
        }

        System.Collections.Generic.Dictionary<string, object> map;

        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name == "set" && binder.CallInfo.ArgumentCount == 2)
            {
                string name = args[0] as string;
                if (name == null)
                {
                    //throw new ArgumentException("name");  
                    result = null;
                    return false;
                }
                if (map == null)
                {
                    map = new System.Collections.Generic.Dictionary<string, object>();
                }
                object value = args[1];
                map.Add(name, value);
                result = value;
                return true;

            }
            return base.TryInvokeMember(binder, args, out result);
        }
    }
}
