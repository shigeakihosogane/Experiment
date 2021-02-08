using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class UnsouModels
    {
        public class Zyuusyoroku
        {
            [System.ComponentModel.DataAnnotations.Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public int ZyuusyorokuId { get; set; }
            public string MeisyouRyaku { get; set; }
            public string MeisyouSei { get; set; }
            public string Zyuusyo1 { get; set; }
            public string Zyuusyo2 { get; set; }
            public string Zyuusyo3 { get; set; }
            public string Zyuusyo4 { get; set; }
            public string DennwaBanngou { get; set; }
            public string FaxBanngou { get; set; }

        }


        public class Syuukasaki
        {
            [Required]
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public string UserId { get; set; }

            [Required]
            public int ZyuusyorokuId { get; set; }
            public int TantoukubunnId { get; set; }
            public virtual Zyuusyoroku Zyuusyoroku { get; set; }

        }

        public class Haisousaki
        {
            [Required]
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public string UserId { get; set; }

            [Required]
            public int ZyuusyorokuId { get; set; }
            public int TantoukubunnId { get; set; }
            public virtual Zyuusyoroku Zyuusyoroku { get; set; }

        }


    }
}