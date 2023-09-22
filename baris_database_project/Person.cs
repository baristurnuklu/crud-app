using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace baris_database_project
{
    public class Person
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }

        public int NameStyle { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int EmailPromotion { get; set; }

        public XmlDocument AdditionalContactInfo { get; set; }

        public XmlDocument Demographics { get; set; }
        public Guid rowquid { get;set; }
        
        public DateTime ModifiedDate { get; set; }

        public void fillPerson(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntityId = (int)dr["BusinessEntityId"];
                PersonType = (string)dr["PersonType"];
                //NameStyle = (int)dr["NameStyle"];
                //Title = (string)dr["Title"];
                FirstName = (string)dr["FirstName"];
                MiddleName = (string)dr["MiddleName"];
                LastName = (string)dr["LastName"];
                //Suffix = (string)dr["Suffix"];
                //EmailPromotion = (int)dr["EmailPromotion"];
                //AdditionalContactInfo = (XmlDocument)dr["AdditionalContactInfo"];
                //Demographics = (XmlDocument)dr["Demographics"];
                //rowquid = (Guid)dr["rowquid"];
                //ModifiedDate = (DateTime)dr["ModifiedDate"];
            }
        }

    }
    
}
