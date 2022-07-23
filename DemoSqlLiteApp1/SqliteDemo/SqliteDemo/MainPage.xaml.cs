using SqliteDemo.Models;
using SqliteDemo.Repository;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Text;

namespace SqliteDemo;

public partial class MainPage : ContentPage
{
	int count = 0;
    private readonly SqliteRepository repository;
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public MainPage()
	{
		repository = new SqliteRepository();
		InitializeComponent();
	}

	private void OnReadClicked(object sender, EventArgs e)
	{
		var records = repository.List();
		var sb = new StringBuilder();
		foreach (var item in records)
		{
			sb.AppendLine($"id: {item.Id}, name: {item.Name}");
		}
		Task.Run(() => ToastMe(sb.ToString()));
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		var x = new MyEntity() { Id = count, Name = $"Test {count}" };

		repository.Create(x);

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async Task ToastMe(string message)
	{        
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = Toast.Make(message, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }
}

