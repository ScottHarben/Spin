// <auto-generated />
namespace Spin.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class PurgePendingChanges : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(PurgePendingChanges));
        
        string IMigrationMetadata.Id
        {
            get { return "201902122026136_PurgePendingChanges"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
