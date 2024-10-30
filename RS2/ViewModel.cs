using Microsoft.Win32;
using RS2.Gvas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RS2
{
	internal class ViewModel : INotifyPropertyChanged
	{
		public ICommand OpenFileCommand { get; }
		public ICommand SaveFileCommand { get; }
		public ICommand ImportFileCommand { get; }
		public ICommand ExportFileCommand { get; }

		public Basic? Basic { get; private set; }
		public ObservableCollection<Character> Characters { get; init; } = new ObservableCollection<Character>();

		public event PropertyChangedEventHandler? PropertyChanged;

		public ViewModel()
		{
			OpenFileCommand = new ActionCommand(OpenFile);
			SaveFileCommand = new ActionCommand(SaveFile);
			ImportFileCommand = new ActionCommand(ImportFile);
			ExportFileCommand = new ActionCommand(ExportFile);
		}

		private void Initialize()
		{
			Characters.Clear();


			// party
			// G01PartySaveInfo -> MPartyMemberStatus -> G01PartyCharaStatus ->
			// {
			//     .....
			//     G01CharaStatus
			// }

			var status = Gvas.Gvas.CreateGvasProperty(0, "MPartyMemberStatus");
			var properties = status.Value as GvasProperty[];
			if (properties != null)
			{
				foreach (var property in properties)
				{
					var character = property as Character;
					if (character == null) continue;
					Characters.Add(character);
				}
			}

			Basic = new Basic();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Basic)));
		}

		private void OpenFile(Object? param)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Open(dlg.FileName))
			{
				Initialize();
			}
		}

		private void SaveFile(Object? param)
		{
			SaveData.Instance().Save();
		}

		private void ImportFile(Object? param)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Import(dlg.FileName);
		}

		private void ExportFile(Object? param)
		{
			var dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Export(dlg.FileName);
		}
	}
}
