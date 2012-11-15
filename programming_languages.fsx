// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System.Net
open System.Net
open System.IO
open System.Text
open System.Text.RegularExpressions

let matches input=
    Regex.Matches(input,"title=.\w*.")
    |> Seq.cast<Match>
//    |> Seq.groupBy (fun m -> m.Value)
//    |> Seq.map (fun (value, groups) -> value, (groups |> Seq.length))

let get_prog_lang()=
    let stream = WebRequest.Create("http://en.wikipedia.org/wiki/List_of_programming_languages").GetResponse().GetResponseStream()
    let reader = new StreamReader(stream,System.Text.Encoding.UTF8)
    let content = reader.ReadToEnd()
    let data = matches(content)
    data
    |>Seq.map(fun (m)->printf "%s"m.Value)

    

    




    