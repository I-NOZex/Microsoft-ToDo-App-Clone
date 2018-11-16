using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Windows.ApplicationModel;
using Windows.Storage;
using Microsoft.Toolkit.Uwp.Helpers;
using MSTODOclone.Models;
using MSTODOclone.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace MSTODOclone.Data
{
    public static class NotebookService
    {

        class CustomResolver : DefaultContractResolver {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
                JsonProperty prop = base.CreateProperty(member, memberSerialization);

                if (prop.DeclaringType == typeof(EmptyTodoItemVM)) {
                    prop.ShouldSerialize = obj => false;
                }

                return prop;
            }
        }

        public static async Task<ObservableCollection<NotebookVM>> FetchDataAsync() {
            try {
                string notebookData = "";

                bool fileExists = await ApplicationData.Current.LocalFolder.FileExistsAsync("todo-data.json");
                if (!fileExists) {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("todo-data.json");

                    StorageFile defaultJsonFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/todo-data.json"));

                    string defaultNotebookData = await FileIO.ReadTextAsync(defaultJsonFile);
                    await FileIO.WriteTextAsync(jsonFile, defaultNotebookData);


                    notebookData = defaultNotebookData;

                } else {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.GetFileAsync("todo-data.json");
                    notebookData = await FileIO.ReadTextAsync(jsonFile);
                }

                ObservableCollection<NotebookVM> Notebooks =
                    JsonConvert.DeserializeObject<ObservableCollection<NotebookVM>>(notebookData);

                return Notebooks;

            }
            catch (Exception e) {
                var a = e;
            }

            return new ObservableCollection<NotebookVM>();
        }

        public static async Task<bool> SaveDataASync(ObservableCollection<NotebookVM> Notebooks) {
            // Serializer settings
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //settings.Formatting = Formatting.None;
            settings.Formatting = Formatting.Indented;

            //FIXME: Find a better way of filtering the «Notebooks» list, to return ToDos that ain't empty
            var filteredNotebooks = new List<NotebookVM>();
            foreach (var nb in Notebooks) {
                filteredNotebooks.Add(nb);
                filteredNotebooks.Last().ToDos.Remove(filteredNotebooks.Last().ToDos.Last());
            }

            string notebookData = JsonConvert.SerializeObject(filteredNotebooks, settings);
            StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("todo-data.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(jsonFile, notebookData);
            return true;
        }
    }
}
