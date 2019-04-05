# LogArquivoCore

Biblioteca .Net Standard para gerar log em arquivo txt.<br>
<br>
Métodos disponiveis:<br>
Log.Excecao(Exception ex)<br>
Log.Erro(string conteudo)<br>
<br>
Nuget Package:<br>
<a href="https://www.nuget.org/packages/LogArquivoCore" target="_blank">LogArquivoCore
 <img src="https://img.shields.io/badge/Nuget-1.0.0-green.svg"/></a><br>
<br>
Requer um arquivo "appsettings.json" na pasta do projeto com a chave GerarLog:<br>
```js
{
  "GerarLog": true
}
```

Exemplo:
```c#
using LogArquivoCore;

try
{
  File.ReadAllText("qualquer.txt");
}
catch (Exception ex)
{
  Log.Excecao(ex);
}
```

Ferramentas:<br>
Visual Studio 2017 Community<br>
.Net Standard 2.0 - Roda em apps .Net Core 2.0 Console/Web<br>
C#<br>
