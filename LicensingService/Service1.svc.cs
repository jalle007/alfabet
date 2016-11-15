using System;
using System.Collections.Generic;
using System.Linq;

namespace LicensingService {
  public class Service1 : IService1 {
    public dbEntities db = new dbEntities();

    public bool AddSubscription(SubscribeViewModel model)
    {
      try {
        Subscriptions sub = new Subscriptions() {
          UserID = model.Email,
          Users = model.Users,
          Databases = model.Databases,
          Features = model.Features,
          Serial = model.Serial,
          Active = true,
          CreatedAt = DateTime.Now
        };
        db.Subscriptions.Add(sub);
        db.SaveChanges();
      } catch (Exception) {
        return false;
      }
      return true;
    }

    //generate new serial
    public string GetNewSerial() {
      SerialsBank ser = (from d in db.SerialsBank
                         where d.Active == true
                         select d).FirstOrDefault();

      if (ser == null)
        return null;
      //else
      ser.Active = false;
      db.SaveChanges();
      return ser.Serial;
    }

    //check if serial is valid
    public bool isValidSerial(string serial) {
      SerialsBank ser = (from d in db.SerialsBank
                         where d.Serial == serial
                         select d).FirstOrDefault();

      return ser!=null;
    }

    // generate new n serial keys and store it in database
    public bool GenerateSerials(int number) {
      List<SerialsBank> list1 = new List<SerialsBank>();
      try {
        for (int i = 0; i < number; i++) {
          Guid guid = Guid.NewGuid();
          list1.Add(new SerialsBank() { Serial = guid.ToString(), Active = true, CreatedAt = DateTime.Now });
        }

        db.SerialsBank.AddRange(list1);
        db.SaveChanges();
      } catch (Exception) {
        return false;
        //  throw;
      }
      return true;
    }


    public string GetData(int value) {
      return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite) {
      if (composite == null) {
        throw new ArgumentNullException("composite");
      }
      if (composite.BoolValue) {
        composite.StringValue += "Suffix";
      }
      return composite;
    }
  }
}
