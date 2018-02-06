using System.Collections.Generic;

public class Create
{
    public Create()
    {
    }


    public static void CreateTxtFile(List<Invoice> items)
    {
        if (items.Count == 0)
        {
            throw new System.ArgumentNullException(nameof(items));
        }

        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\Invoice.txt", true))
        {
            foreach (var item in items)
            {
                file.WriteLine(item.Id+" "+item.Title+" "+ item.TransactionOwner);
            }
        }
    }


}

