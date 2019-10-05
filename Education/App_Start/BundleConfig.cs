using System.Web.Optimization;

namespace Education
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            /*
             * Buradaki {version}  yazımı projemizde birden fazla  aynı dosyadan mevcut ise hepsini yükler
             */
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/all").Include(
                "~/Content/Theme/template/css/style.css",
                "~/Content/Theme/template/vendors/css/vendor.bundle.addons.css",
                "~/Content/Theme/template/vendors/css/vendor.bundle.base.css"
                ));

            bundles.Add(new ScriptBundle("~/js/all").Include(
                "~/Content/Theme/template/vendors/js/vendor.bundle.base.js",
                "~/Content/Theme/template/vendors/js/vendor.bundle.addons.js",
                "~/Content/Theme/template/js/template.js",
                "~/Content/Theme/template/js/data-table.js"
                ));
            bundles.Add(new ScriptBundle("~/custom/js").Include(
                "~/Scripts/Teacher.js",
                "~/Scripts/Floor.js"));

            /*
             * Örnek Yazım
             * "~/Scripts/*.js" burada bu dosya içindeki  tüm  js yükletir
             */

            /*
             *  Bundle işlemlerinde  Javasicript ve  Css dosyalarımızı
             * bu şekilde paketleyebiliriz.
             * Şuan bu şekilde kullanımda  bile  her css ve js dosyası tek tek
             * yüklenir  önbellekte tutulmuş olsa bile  dosya sayısı  arttıkça
             * yine bellir bir  yük ve  perfosmans  gerektirir.
             * Bunun önüne  geçmek için 
             */
            BundleTable.EnableOptimizations = false;
            /*
             * Yukarıda ki kod blogu bize şunu sağlar  bu gruplanmış css ve  js
             * dosylarını ayrı  birer  (tek ) dosya da tutar  minimize eder ve
             * sayfaya  yükler. Eger projemiz debug modda ise yazılmamısı durumunda
             * yada false olarak ayarlanması durumunda tek tek dosyaları  yükler .
             * Taki  projemizi release moda çekene release modda yazmasak bile minimize eder.
             */
        }
    }
}
