﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Zyuusyoroku
    { 
        [Key]
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
        public string EriaId { get; set; }

    }


    public class Syuukasaki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ZyuusyorokuId { get; set; }
        public int EriaId { get; set; }


    }

    public class Haisousaki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ZyuusyorokuId { get; set; }
        public int EriaId { get; set; }
        public virtual Zyuusyoroku MeisyouRyaku { get; set; }
        public virtual Zyuusyoroku MeisyouSei { get; set; }
        public virtual Zyuusyoroku Zyuusyo1 { get; set; }
        public virtual Zyuusyoroku Zyuusyo2 { get; set; }
        public virtual Zyuusyoroku Zyuusyo3 { get; set; }
        public virtual Zyuusyoroku Zyuusyo4 { get; set; }
        public virtual Zyuusyoroku DennwaBanngou { get; set; }
        public virtual Zyuusyoroku FaxBanngou { get; set; }
    }

    public class Haisousaki2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ZyuusyorokuId { get; set; }
        public int EriaId { get; set; }
        public virtual Zyuusyoroku MeisyouRyaku { get; set; }
        public virtual Zyuusyoroku MeisyouSei { get; set; }
        public virtual Zyuusyoroku Zyuusyo1 { get; set; }
        public virtual Zyuusyoroku Zyuusyo2 { get; set; }
        public virtual Zyuusyoroku Zyuusyo3 { get; set; }
        public virtual Zyuusyoroku Zyuusyo4 { get; set; }
        public virtual Zyuusyoroku DennwaBanngou { get; set; }
        public virtual Zyuusyoroku FaxBanngou { get; set; }
    }

    public class Haisousaki3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ZyuusyorokuId { get; set; }
        public int EriaId { get; set; }
        public virtual Zyuusyoroku Zyuusyoroku { get; set; }

    }



}