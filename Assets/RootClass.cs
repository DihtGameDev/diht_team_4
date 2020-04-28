using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string priceStr;
        List<IWebElement> SearchHalava = Browser.FindElements(By.CssSelector("td[class='bj bp']")).ToList();
        for (int i = 0; i < 10; i++)
        {
            priceStr = System.Text.RegularExpressions.Regex.Match(SearchHalava[i].Text, "[0-9].[0-9]*").Value;
            priceStr = priceStr.Replace('.', ',');
            textBox1.AppendText(priceStr + "\n");
            double Conv = Convert.ToDouble(priceStr);
            if (Conv < 1)
            {
                label1.Text = "z";
            }
        }
        
        class QuickSorting
        {
            public static void sorting(double[] arr, long first, long last)
            {
                double p = arr[(last - first) / 2 + first];
                double temp;
                long i = first, j = last;
                while (i <= j)
                {
                    while (arr[i] < p && i <= last) ++i;
                    while (arr[j] > p && j >= first) --j;
                    if (i <= j)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        ++i; --j;
                    }
                }
                if (j > first) sorting(arr, first, j);
                if (i < last) sorting(arr, i, last);
            }
        }
 
        class Test
        {
            static void Main(string[] args)
            {
                double[] arr = new double[10];
 
                
                Random rd = new Random();
                for (int i = 0; i < arr.Length; ++i)
                {
                    arr[i] = rd.Next(1, 101);
                }
                System.Console.WriteLine("The array before sorting:");
                foreach (double x in arr)
                {
                    System.Console.Write(x + " ");
                }
 
                //сортировка
                QuickSorting.sorting(arr, 0, arr.Length - 1);
                System.Console.WriteLine("\n\nThe array after sorting:");
                foreach (double x in arr)
                {
                    System.Console.Write(x + " ");
                }
                System.Console.WriteLine("\n\nPress the <Enter> key");
                System.Console.ReadLine();
            }
        }
    }
    private static IEnumerable<double> QuickSort(IEnumerable<double> en)
    {
        if (!en.Any() || !en.Skip(1).Any()) return en;
        double first = en.First();
        ILookup<int, double> lookup = en.ToLookup(x => x.CompareTo(first));
        return QuickSort(lookup[-1]).Concat(lookup[0]).Concat(QuickSort(lookup[1]));
    }
 
    public static void Main()
    {
        foreach (double x in QuickSort(Enumerable.Repeat(new Random(), 20).Select(r => r.NextDouble())))
        {
            Console.WriteLine(x);
        }
    }
    
    static class Program
    {
        
    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process pr = RI();
            if (pr != null)
                MessageBox.Show("Приложение уже запущено!!!","Дупликат!!!");
            else
                Application.Run(new Form1());
        }
        public static Process RI()
        {
            Process current = Process.GetCurrentProcess();
            Process[] pr = Process.GetProcessesByName(current.ProcessName);
            foreach (Process i in pr)
            {
                if (i.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return i;
                    }
                }
            }
            return null;
        }
    }
}

public class AOTProblemExample : MonoBehaviour, IReceiver
{
    public enum AnyEnum 
    {
        Zero,
        One,
    }

    void Start() 
    {
        // Subtle trigger: The type of manager *must* be
        // IManager, not Manager, to trigger the AOT problem.
        IManager manager = new Manager();
        manager.SendMessage(this, AnyEnum.Zero);
    }

    public void OnMessage<T>(T value) 
    {
        Debug.LogFormat("Message value: {0}", value);
    }
}

public class Manager : IManager 
{
    public void SendMessage<T>(IReceiver target, T value) {
        target.OnMessage(value);
    }
}

public interface IReceiver
{
    void OnMessage<T>(T value);
}

public void UsedOnlyForAOTCodeGeneration() 
{
OnMessage(AnyEnum.Zero);
new Manager().SendMessage(null, AnyEnum.Zero);
throw new InvalidOperationException("This method is used for AOT code generation only. Do not call it at runtime.");
}

public interface IManager 
{
    void SendMessage<T>(IReceiver target, T value);
}
