using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RS2
{
	internal class ViewModel
	{
		public ICommand OpenFileCommand { get; }
		public ICommand SaveFileCommand { get; }
		public ICommand ImportFileCommand { get; }
		public ICommand ExportFileCommand { get; }

		public ObservableCollection<Character> Characters { get; init; } = new ObservableCollection<Character>();

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
			// G01PartySaveInfo -> 
			// G01CharaStatus
			var addresses = SaveData.Instance().FindAddress("G01CharaStatus", 0);
			foreach (var address in addresses)
			{
				Characters.Add(new Character(address));
			}

			// money
			// G01GamePlayDataSaveInfo -> Crown
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
