using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{

    public class RolesController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext().
                    GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ??
                    HttpContext.GetOwinContext().
                    Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Roles（登録済みロールの一覧）
        // Model は ApplicationRole
        public ActionResult Index()
        {
            var roles =
              RoleManager.Roles.OrderBy(role => role.Name);
            return View(roles);
        }

        // GET: Roles/Details/Id（指定 Id のロール詳細）
        // 上の一覧以上の情報は含まれないので不要かも・・・
        // Model は ApplicationRole
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }

            var target = await RoleManager.FindByIdAsync(id);
            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        // GET: Roles/Create（新規ロール作成・登録）
        // Model は上に定義した RoleModel クラス
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create（新規ロール作成・登録）
        // Model は上に定義した RoleModel クラス
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                // ユーザーが入力したロール名を model.Role から取得し
                // て ApplicationRole　を生成
                var role = new ApplicationRole { Name = model.Role };

                //　上の ApplicationRole から新規ロールを作成・登録
                var result = await RoleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    // 登録に成功したら Roles/Index にリダイレクト
                    return RedirectToAction("Index", "Roles");
                }

                // result.Succeeded が false の場合 ModelSate にエ
                // ラー情報を追加しないとエラーメッセージが出ない。
                // AccountController と同様に AddErrors メソッドを
                // 定義して利用（一番下に定義あり）
                AddErrors(result);
            }

            // ロールの登録に失敗した場合、登録画面を再描画
            return View(model);
        }

        // GET: Roles/Edit/Ed（指定 Id のロール情報の更新）
        // ここで更新できるのはロール名のみ
        // Model は上に定義した RoleModel クラス
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                    HttpStatusCode.BadRequest);
            }

            var target = await RoleManager.FindByIdAsync(id);

            if (target == null)
            {
                return HttpNotFound();
            }

            RoleModel model = new RoleModel() { Role = target.Name };

            return View(model);
        }

        // POST: Roles/Edit/Id（指定 Id のロール情報の更新）
        // ここで更新できるのはロール名のみ
        // Model は上に定義した RoleModel クラス
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>
                            Edit(string id, RoleModel model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                    HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                var target = await RoleManager.FindByIdAsync(id);

                // ユーザーが入力したロール名を model.Role から取得し
                // て ApplicationRole の Name を書き換え
                target.Name = model.Role;

                // Name を書き換えた ApplicationRole で更新をかける
                var result = await RoleManager.UpdateAsync(target);

                if (result.Succeeded)
                {
                    // 更新に成功したら Roles/Index にリダイレクト
                    return RedirectToAction("Index", "Roles");
                }

                // result.Succeeded が false の場合 ModelSate にエ
                // ラー情報を追加しないとエラーメッセージが出ない。
                AddErrors(result);
            }

            // 更新に失敗した場合、編集画面を再描画
            return View(model);
        }

        // GET: Roles/Delete/Id（指定 Id のロールを削除）
        // 階層更新が行われているようで、ユーザーがアサインされて
        // いるロールも削除可能。
        // Model は ApplicationRole
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                    HttpStatusCode.BadRequest);
            }

            var target = await RoleManager.FindByIdAsync(id);

            if (target == null)
            {
                return HttpNotFound();
            }

            return View(target);
        }

        // POST: Roles/Delete/Id（指定 Id のロールを削除）
        // Model は ApplicationRole
        // 上の Delete(string id) と同シグネチャのメソッド
        // は定義できないので、メソッド名を変えて、下のよう
        // に ActionName("Delete") を設定する
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>
                            DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                    HttpStatusCode.BadRequest);
            }

            var target = await RoleManager.FindByIdAsync(id);

            if (target == null)
            {
                return HttpNotFound();
            }

            // ユーザーがアサインされているロールも以下の一行で
            // 削除可能。内部で階層更新が行われているらしい。
            var result = await RoleManager.DeleteAsync(target);

            if (result.Succeeded)
            {
                // 削除に成功したら Roles/Index にリダイレクト
                return RedirectToAction("Index", "Roles");
            }

            // result.Succeeded が false の場合 ModelSate にエ
            // ラー情報を追加しないとエラーメッセージが出ない。
            AddErrors(result);

            // 削除に失敗した場合、削除画面を再描画
            return View(target);
        }


        // 以下は:
        // (1) UserWithRoles で、上の画像のように、登録済みユーザー
        //     の一覧と各ユーザーへのロールのアサイン状況を表示し、
        // (2) Edit ボタンクリックで EditRoleAssignment に遷移し、
        //     当該ユーザーへのロールのアサインを編集して保存する
        // ・・・ためのもの。

        // GET: Roles/UserWithRoles
        // ユーザー一覧と各ユーザーにアサインされているロールを表示
        // Model は上に定義した UserWithRoleInfo クラス
        public async Task<ActionResult> UserWithRoles()
        {
            var model = new List<UserWithRoleInfo>();

            // ToList() を付与してここで DB からデータを取得して
            // DataReader を閉じておかないと、下の IsInRole メソッド
            // でエラーになるので注意
            var users = UserManager.Users.
                        OrderBy(user => user.UserName).ToList();
            var roles = RoleManager.Roles.
                        OrderBy(role => role.Name).ToList();

            foreach (ApplicationUser user in users)
            {
                UserWithRoleInfo info = new UserWithRoleInfo();
                info.UserId = user.Id;
                info.UserName = user.UserName;
                info.UserEmail = user.Email;

                foreach (ApplicationRole role in roles)
                {
                    RoleInfo roleInfo = new RoleInfo();
                    roleInfo.RoleName = role.Name;
                    roleInfo.IsInThisRole = await
                        UserManager.IsInRoleAsync(user.Id, role.Name);
                    info.UserRoles.Add(roleInfo);
                }
                model.Add(info);
            }

            return View(model);
        }

        // GET: Roles/EditRoleAssignment/Id
        // 指定 Id のユーザーのロールへのアサインの編集
        // Model は上に定義した UserWithRoleInfo クラス
        public async Task<ActionResult>
                            EditRoleAssignment(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                    HttpStatusCode.BadRequest);
            }

            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            UserWithRoleInfo model = new UserWithRoleInfo();
            model.UserId = user.Id;
            model.UserName = user.UserName;
            model.UserEmail = user.Email;

            // ToList() を付与しておかないと下の IsInRole メソッド
            // で　DataReader が閉じてないというエラーになる
            var roles = RoleManager.Roles.
                        OrderBy(role => role.Name).ToList();

            foreach (ApplicationRole role in roles)
            {
                RoleInfo roleInfo = new RoleInfo();
                roleInfo.RoleName = role.Name;
                roleInfo.IsInThisRole = await
                    UserManager.IsInRoleAsync(user.Id, role.Name);
                model.UserRoles.Add(roleInfo);
            }

            return View(model);
        }

        // GET: Roles/EditRoleAssignment/Id
        // 指定 Id のユーザーのロールへのアサインの編集
        // Model は上に定義した UserWithRoleInfo クラス
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>
          EditRoleAssignment(string id, UserWithRoleInfo model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                    HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                IdentityResult result;

                foreach (RoleInfo roleInfo in model.UserRoles)
                {
                    // id のユーザーが roleInfo.RoleName のロールに属して
                    // いるか否か。以下でその情報が必要。
                    bool isInRole = await
                      UserManager.IsInRoleAsync(id, roleInfo.RoleName);

                    // roleInfo.IsInThisRole には編集画面でロールのチェッ
                    // クボックスのチェック結果が格納されている
                    if (roleInfo.IsInThisRole)
                    {
                        // チェックが入っていた場合

                        // 既にロールにアサイン済みのユーザーを AddToRole
                        // するとエラーになるので以下の判定が必要
                        if (isInRole == false)
                        {
                            result = await UserManager.
                                     AddToRoleAsync(id, roleInfo.RoleName);
                            if (!result.Succeeded)
                            {
                                AddErrors(result);
                                return View(model);
                            }
                        }
                    }
                    else
                    {
                        // チェックが入っていなかった場合

                        // ロールにアサインされてないユーザーを
                        // RemoveFromRole するとエラーになるので以下の
                        // 判定が必要
                        if (isInRole == true)
                        {
                            result = await UserManager.
                                     RemoveFromRoleAsync(id, roleInfo.RoleName);
                            if (!result.Succeeded)
                            {
                                AddErrors(result);
                                return View(model);
                            }
                        }
                    }
                }

                // 編集に成功したら Roles/UserWithRoles にリダイレクト
                return RedirectToAction("UserWithRoles", "Roles");
            }

            // 編集に失敗した場合、編集画面を再描画
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }
            }

            base.Dispose(disposing);
        }

        // ModelSate にエラー情報を追加するためのヘルパメソッド
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}




