// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Clietn.Controllers
{
    public partial class AdminController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AdminController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AdminController Actions { get { return MVC.Admin; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string AddAlbum = "AddAlbum";
            public readonly string AddGenre = "AddGenre";
            public readonly string AddSongWriter = "AddSongWriter";
            public readonly string AddTrack = "AddTrack";
            public readonly string StartAdmin = "StartAdmin";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string AddAlbum = "AddAlbum";
            public const string AddGenre = "AddGenre";
            public const string AddSongWriter = "AddSongWriter";
            public const string AddTrack = "AddTrack";
            public const string StartAdmin = "StartAdmin";
        }


        static readonly ActionParamsClass_AddAlbum s_params_AddAlbum = new ActionParamsClass_AddAlbum();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddAlbum AddAlbumParams { get { return s_params_AddAlbum; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddAlbum
        {
            public readonly string albumAdminModel = "albumAdminModel";
        }
        static readonly ActionParamsClass_AddGenre s_params_AddGenre = new ActionParamsClass_AddGenre();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddGenre AddGenreParams { get { return s_params_AddGenre; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddGenre
        {
            public readonly string genreAdminModel = "genreAdminModel";
        }
        static readonly ActionParamsClass_AddSongWriter s_params_AddSongWriter = new ActionParamsClass_AddSongWriter();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddSongWriter AddSongWriterParams { get { return s_params_AddSongWriter; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddSongWriter
        {
            public readonly string songWriterAdminModel = "songWriterAdminModel";
        }
        static readonly ActionParamsClass_AddTrack s_params_AddTrack = new ActionParamsClass_AddTrack();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddTrack AddTrackParams { get { return s_params_AddTrack; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddTrack
        {
            public readonly string trackAdminModel = "trackAdminModel";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string AddAlbum = "AddAlbum";
                public readonly string AddGenre = "AddGenre";
                public readonly string AddSongWriter = "AddSongWriter";
                public readonly string AddTrack = "AddTrack";
                public readonly string StartAdmin = "StartAdmin";
            }
            public readonly string AddAlbum = "~/Views/Admin/AddAlbum.cshtml";
            public readonly string AddGenre = "~/Views/Admin/AddGenre.cshtml";
            public readonly string AddSongWriter = "~/Views/Admin/AddSongWriter.cshtml";
            public readonly string AddTrack = "~/Views/Admin/AddTrack.cshtml";
            public readonly string StartAdmin = "~/Views/Admin/StartAdmin.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AdminController : Clietn.Controllers.AdminController
    {
        public T4MVC_AdminController() : base(Dummy.Instance) { }

        [NonAction]
        partial void AddAlbumOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddAlbum()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddAlbum);
            AddAlbumOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddAlbumOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Clietn.Models.AdminViewModel.AlbumAdminModel albumAdminModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddAlbum(Clietn.Models.AdminViewModel.AlbumAdminModel albumAdminModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddAlbum);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "albumAdminModel", albumAdminModel);
            AddAlbumOverride(callInfo, albumAdminModel);
            return callInfo;
        }

        [NonAction]
        partial void AddGenreOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddGenre()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddGenre);
            AddGenreOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddGenreOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Client.Models.AdminViewModel.GenreAdminModel genreAdminModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddGenre(Client.Models.AdminViewModel.GenreAdminModel genreAdminModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddGenre);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "genreAdminModel", genreAdminModel);
            AddGenreOverride(callInfo, genreAdminModel);
            return callInfo;
        }

        [NonAction]
        partial void AddSongWriterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddSongWriter()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddSongWriter);
            AddSongWriterOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddSongWriterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Clietn.Models.AdminViewModel.SongWriterAdminModel songWriterAdminModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddSongWriter(Clietn.Models.AdminViewModel.SongWriterAdminModel songWriterAdminModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddSongWriter);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "songWriterAdminModel", songWriterAdminModel);
            AddSongWriterOverride(callInfo, songWriterAdminModel);
            return callInfo;
        }

        [NonAction]
        partial void AddTrackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddTrack()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddTrack);
            AddTrackOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddTrackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Clietn.Models.AdminViewModel.TrackAdminModel trackAdminModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult AddTrack(Clietn.Models.AdminViewModel.TrackAdminModel trackAdminModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddTrack);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "trackAdminModel", trackAdminModel);
            AddTrackOverride(callInfo, trackAdminModel);
            return callInfo;
        }

        [NonAction]
        partial void StartAdminOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult StartAdmin()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.StartAdmin);
            StartAdminOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
