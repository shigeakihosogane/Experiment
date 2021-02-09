using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{

    // アクションメソッド Create, Edit 用の Model
    public class RoleModel
    {
        [Key]
        [Required]
        [StringLength(100,ErrorMessage = "{0} は {2} 文字以上",MinimumLength = 3)]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }

    // アクションメソッド UserWithRoles, EditRoleAssignment
    //  (各ユーザーのロール一覧表示、ロールのアサイン・削除) 
    // 用の Model
    public class UserWithRoleInfo
    {
        public UserWithRoleInfo()
        {
            UserRoles = new List<RoleInfo>();
        }
        [Key]
        public string UserId { set; get; }
        public string UserName { set; get; }
        public string UserEmail { set; get; }

        public IList<RoleInfo> UserRoles { set; get; }
    }

    public class RoleInfo
    {   [Key]
        public string RoleName { set; get; }
        public bool IsInThisRole { set; get; }
    }





}
