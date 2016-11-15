using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LicensingService {
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    /*
     * product id
     * users
     * features
     * databases
     * email
     * generate rnd num on each number
     */
  [ServiceContract]
  public interface IService1 {

    [OperationContract]
    string GetData(int value);

    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    string GetNewSerial( );

    [OperationContract]
    bool GenerateSerials( int number);

    [OperationContract]
    bool isValidSerial(string serial);

    [OperationContract]
    bool AddSubscription(SubscribeViewModel model);

    // TODO: Add your service operations here
  }

  [DataContract]
  public class SubscribeViewModel {
    [DataMember]
    public string Email { get; set; }

    [DataMember]
    public int Users { get; set; }

    [DataMember]
    public int Features { get; set; }

    [DataMember]
    public int Databases { get; set; }

    [DataMember]
    public string Serial { get; set; }
  }

  // Use a data contract as illustrated in the sample below to add composite types to service operations.
  [DataContract]
  public class CompositeType {
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue {
      get { return boolValue; }
      set { boolValue = value; }
    }

    [DataMember]
    public string StringValue {
      get { return stringValue; }
      set { stringValue = value; }
    }
  }
}
