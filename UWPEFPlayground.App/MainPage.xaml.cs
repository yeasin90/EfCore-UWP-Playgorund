using EFGenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPEFPlayground.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            try
            {
                using (var db = new MyDbContext())
                {
                    db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ISectionRepository sectionRepo = new SectionRepository();
            await sectionRepo.Insert(new Section()
            {
                SectionName = "Section1",
                Students = new List<Student>() { new Student() { Name = "Student1" }, new Student() { Name = "Student2" } }
            });

            var sections = await sectionRepo.GetAll();

            base.OnNavigatedTo(e);
        }
    }
}
