using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsDB
{
    public static class PackageDB
    {
        public static List<Package> GetPackages(TravelExpertsContext db)
        {
            List<Package> packages = db.Packages.ToList();
            return packages;
        }

        public static Package GetPackageById(TravelExpertsContext db, int id)
        {
            Package? pck = db.Packages.FirstOrDefault(p => p.PackageId == id);
            return pck!;
        }
    }
}
