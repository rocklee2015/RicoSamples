
namespace Rico.T4Sample.S1_FromXmlToCs
{
    public static class Messages
    {
	             public static class  Validation
        {
			            public static MessageEntry MandatoryField = new MessageEntry("MandatoryField","The {0} is mandatory.","Validation");
			                 public static MessageEntry GreaterThan = new MessageEntry("GreaterThan","The {0} must be greater than {1}.","Validation");
			     	    }
                  public static class  Confirmation
        {
			            public static MessageEntry ReallyDelete = new MessageEntry("ReallyDelete","你真的想删除 {0}么？","Confirmation");
			     	    }
              }
}

