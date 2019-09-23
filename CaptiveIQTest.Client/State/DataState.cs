using CaptiveIQTest.SharedObjs;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

public class DataState
{
    private static HttpClient httpClient = new HttpClient();

    public CIQUser User { get; private set; }

    private char selectedColumn;

    private int selectedRow;

    public event EventHandler StateChanged;

    public CellData SelectedCell 
    { 
        get 
        {
            return this.User.GetCell(this.selectedColumn, this.selectedRow);
        }
    } 
        

    public string SelectedFormula => this.SelectedCell.Formula;

    public async void SetUser(string userId)
    {
        var result = await httpClient.GetAsync($"https://zys7hpgnod.execute-api.us-east-1.amazonaws.com/Prod/api/User/{userId}");
        this.User = JsonConvert.DeserializeObject<CIQUser>(result.Content.ReadAsStringAsync().Result);
        this.StateHasChanged();
    }

    public async void SetSelectedCell(char column, int row)
    {
        Console.WriteLine($"Selected cell {column}, {row}");
        this.selectedColumn = column;
        this.selectedRow = row;
        this.StateHasChanged();
    }

    public async void SetCellValue(string value)
    {
        this.SelectedCell.Data = value;
        this.SelectedCell.Formula = string.Empty;
        this.updateUser();
        StateHasChanged();
    }

    public async void SetCellFormula(string value)
    {
        this.SelectedCell.Formula = value;
        this.updateUser();
        StateHasChanged();
    }

    private async void updateUser()
    {
        var payload = new StringContent(JsonConvert.SerializeObject(this.User), Encoding.UTF8, "application/json");
        Console.WriteLine($"payload: {payload}");
        var result = await httpClient.PutAsync($"https://zys7hpgnod.execute-api.us-east-1.amazonaws.com/Prod/api/User/{this.User.Id}", payload);
        this.User = JsonConvert.DeserializeObject<CIQUser>(result.Content.ReadAsStringAsync().Result);
        this.StateHasChanged();
    }

    private void StateHasChanged()
    {
        // This will update any subscribers
        // that the counter state has changed
        // so they can update themselves
        // and show the current counter value
        StateChanged?.Invoke(this, EventArgs.Empty);
    }
}