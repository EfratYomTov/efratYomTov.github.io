﻿using System.Web;
using System.Web.Optimization;

namespace Twitter.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //--------- Script Bundle

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/sources/jquery/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/sources/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/sources/bootstrap/bootstrap.js",
                      "~/Scripts/sources/bootstrap/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                 "~/Scripts/sources/angular/1.7.9/angular.min.js",
                 "~/Scripts/sources/angular/1.7.9/angular-route.min.js",
                 "~/Scripts/sources/angular/1.7.9/angular-animate.min.js",
                 "~/Scripts/sources/angular/1.7.9/angular-loader.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/angular/app")
                .IncludeDirectory("~/Scripts/app", "*.js", true)
                .IncludeDirectory("~/Scripts/app", "*.css", true));


            //--------- Style Bundle

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
