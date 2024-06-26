﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace ProjectTW.Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bootstrap style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Template/assets/plugins/bootstrap/css/bootstrap.min.css",
                "~/Template/assets/plugins/pace/pace-theme-flash.css",
                "~/Content/font-awesome.min.css",
                "~/Template/assets/css/animate.min.css",
                "~/Template/assets/plugins/perfect-scrollbar/perfect-scrollbar.css")
                .Include("~/Template/assets/plugins/icheck/skins/minimal/white.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/plugins/css").Include(
                "~/Template/assets/plugins/morris-chart/css/morris.css",
                "~/Template/assets/plugins/jquery-ui/smoothness/jquery-ui.min.css",
                "~/Template/assets/plugins/rickshaw-chart/css/graph.css",
                "~/Template/assets/plugins/rickshaw-chart/css/detail.css",
                "~/Template/assets/plugins/rickshaw-chart/css/legend.css",
                "~/Template/assets/plugins/rickshaw-chart/css/extensions.css",
                "~/Template/assets/plugins/rickshaw-chart/css/rickshaw.min.css",
                "~/Template/assets/plugins/rickshaw-chart/css/lines.css",
                "~/Template/assets/plugins/datepicker/css/datepicker.css")
                .Include("~/Template/assets/plugins/icheck/skins/minimal/white.css", new CssRewriteUrlTransform()));

            // Core CSS template
            bundles.Add(new StyleBundle("~/bundles/core/css").Include(
                "~/Template/assets/css/style.css",
                "~/Template/assets/css/responsive.css")
                .Include("~/Template/assets/plugins/perfect-scrollbar/perfect-scrollbar.css", new CssRewriteUrlTransform()));

            // Core JS framework
            bundles.Add(new ScriptBundle("~/bundles/core/js").Include(
                "~/Template/assets/js/jquery-3.2.1.min.js",
                "~/Template/assets/js/popper.min.js",
                "~/Template/assets/js/jquery.easing.min.js",
                "~/Template/assets/plugins/bootstrap/js/bootstrap.min.js",
                "~/Template/assets/plugins/pace/pace.min.js",
                "~/Template/assets/plugins/perfect-scrollbar/perfect-scrollbar.min.js",
                "~/Template/assets/plugins/viewport/viewportchecker.js"));

            // Other scripts
            bundles.Add(new ScriptBundle("~/bundles/other/js").Include(
                "~/Template/assets/plugins/rickshaw-chart/vendor/d3.v3.js",
                "~/Template/assets/plugins/jquery-ui/smoothness/jquery-ui.min.js",
                "~/Template/assets/plugins/rickshaw-chart/js/Rickshaw.All.js",
                "~/Template/assets/plugins/sparkline-chart/jquery.sparkline.min.js",
                "~/Template/assets/plugins/easypiechart/jquery.easypiechart.min.js",
                "~/Template/assets/plugins/morris-chart/js/raphael-min.js",
                "~/Template/assets/plugins/morris-chart/js/morris.min.js",
                "~/Template/assets/js/chart-morris.js",
                "~/Template/assets/plugins/gauge/gauge.min.js",
                "~/Template/assets/plugins/icheck/icheck.min.js",
                "~/Template/assets/plugins/datepicker/js/datepicker.js",
                "~/Template/assets/plugins/autosize/autosize.min.js",
                "~/Template/assets/plugins/inputmask/min/jquery.inputmask.bundle.min.js"));

            // Include jQuery separately
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Template/assets/js/jquery-3.2.1.min.js",
                "~/Template/assets/js/jquery.easing.min.js",
                "~/Template/assets/plugins/jquery-ui/smoothness/jquery-ui.min.js",
                "~/Template/assets/plugins/calendar/moment.min.js",
                "~/Template/assets/plugins/jquery-ui/smoothness/jquery-ui.min.js",
                "~/Template/assets/plugins/calendar/fullcalendar.min.js",
                "~/Template/assets/plugins/icheck/icheck.min.js",
                "~/Template/data/calendars/hos-events.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom/js").Include("~/Template/assets/js/scripts.js"));
        }
    }
}