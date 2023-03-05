using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WCFService1 : IWCFService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value * 2);
        }

        public CompositeType GetData2()
        {
            return new CompositeType
            {
                BoolValue = true,
                StringValue = "true"
            };
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Time()
        {
            return DateTime.Now.ToString();
        }
    }
}
