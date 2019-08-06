using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.DATA.Models
{
    public class PostTag
    {
        public string PostId { get; set; }
        public string TagId { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
