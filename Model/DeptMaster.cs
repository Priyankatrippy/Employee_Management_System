using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMS_Full_Stack_App.Model
{
    [Table("DeptMaster")]
    public class DeptMaster
    {
   
      
            [Key]
            public int DeptCode { get; set; }
            public string? DeptName { get; set; }
            //public  virtual ICollection<EmpProfile> EmpProfiles { get; set; }
        
    }
}

