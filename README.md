
Blazor アプリケーションプログラミング自習書
============================================

概要 - Blazor とは
----------------------------------------

"Blazor" (ブレイザー) とは、C# 言語を用いて Single Page Web アプリケーション (SPA) を開発、実行する、フレームワーク/実行環境/開発環境です。

C# ソースコードを JavaScript に変換する**のではなく**、Web ブラウザの WebAssembly の仕組みの上に .NET 実行環境を構築することで実現されています。  
**この Web ブラウザ上の .NET 実行環境が .NET アセンブリ (.dll) を読み込んで IL (中間言語) を実行**します。

Blazor はこの実行環境の上で SPA フレームワークを提供しており、**ビュー (コンポーネントの HTML テンプレート部分) は Razor 構文**で記述します。

開発は Microsoft の ASP.NET 開発チームに引き継がれており、Apache 2.0 ライセンスのオープンソースソフトウェアとなっています。

本稿執筆時点での Blazor は v.0.9.0 であり、また、**実験的プロジェクト**として位置づけされています。

この自習書について
----------------------------------------

### 自習書作成の背景

Blazor はまだ実験的プロジェクトとしての位置づけで、製品レベルでの採用は控えるように広報されています。

しかしながら、**Blazor は SPA アプリケーション開発者の負担を減らし、よりよい生産性向上をもたらす可能性**を秘めています。

そこでこの Blazor の可能性をより多くの開発者に体験していただき、Blazor を事前評価していただければと考え、この「Blazor 自習書 (自習教材)」を作成しました。

### 概要

この「Blazor 自習書」では、CRUD 操作を含む SPA アプリケーションを Blazor を使って作成する手順を、1ステップごとに分けて解説しています。

また、ステップごとの完成ソースコードも提供しています。

この手順に沿って作業を進めることで、**Blazor プログラミングの主だった構成要素を習得・体験**できます。  
加えてその開発作業の中で、**IDE 支援がどのように役立つか**も体験することができます。

### コンテンツ

自習書テキスト、および各ステップのソースコードは、**[Release ページ](https://github.com/jsakamoto/self-learning-materials-for-blazor-jp/releases)で配布している Zip アーカイブをダウンロード**して入手してください。

自習書テキストは、PDF ファイルの形式でこの Zip アーカイブ内に収録しています。

また、本リポジトリの v.0.9.0 ブランチには、自習書テキストで解説している1ステップを 1コミットとして履歴を記録したソースコードも収録してあります。


想定する本自習書の利用者層
----------------------------------------

本自習書では、サーバー側実装として ASP.NET Core MVC を採用しています。  
また Blazor は基本的にプログラミング言語は C# が想定されています。

そのため、本自習書では下記のような開発者を想定しております。

- HTML/CSS/JavaScript を用いた Web アプリケーション開発の知識がある
- C# によるプログラミングの知識がある
- 加えて ASP.NET Core MVC によるサーバーサイド Web アプリケーション開発の知識があるとなお可

> ※ Angular, React, Vue などといった JavaScript SPA フレームワークの知識・経験は必ずしも必要としないことと考えていますが、もし何かしら SPA フレームワークの知識・経験があれば、Blazor の理解にも役立つと思います。


必要な開発環境
----------------------------------------

本稿執筆時点で、本自習書による Blazor 開発を実践するにあたり必要な開発環境は下記のとおりです。

- [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [.NET Core 3.0 Preview 3 SDK (3.0.100-preview3-010431)](https://dotnet.microsoft.com/download/dotnet-core/3.0)
- [Visual Studio 2019 - 16.0 Preview 1 以降](https://visualstudio.microsoft.com/vs/preview/)
    - "ASP.NET と Web 開発" ワークロードが選択されていること
    - "VS Live Share - Preview" 拡張が有効であること
- 上記 Visual Studio に [Blazor 拡張](https://marketplace.visualstudio.com/items?itemName=aspnet.blazor)を追加
- 以上の環境をインストールし利用可能な Windows OS

なお、本自習書では Windows OS 上で Visual Studio 2019 Preview 4 以降を使っての手順で説明しております が、Blazor アプリ開発にあたっては、最低限、 

- [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [.NET Core 3.0 Preview 3 SDK (3.0.100-preview3-010431)](https://dotnet.microsoft.com/download/dotnet-core/3.0)
- および任意のテキストエディタ 

さえあれば、"dotnet" CLI (Command Line Interface) を用いて、Linux 各種ディストリビューションや macOS 上でも実践可能です (本書では割愛いたします)。 

> ※1 - Visual Studio 2019 は、無償利用可能な(但しライセンス条項に違反しない場合) Community Edition で可。  
> ※2 - Visual Studio は、複数のバージョンやインスタンスを、ひとつの OS 上に互いの干渉なくいくつもインストールして使用することが可能です。


ライセンス
----------------------------------------

本 GitHub リポジトリに含まれる自習書テキスト、及び、ソースコードは、[The Unlicense](LICENSE) として提供します。

商用・非商用に関係なく、また、クレジット表示も不要で、本リポジトリに含まれるテキストやソースコードを再利用・改変・再配布が可能です。


サポート
----------------------------------------

本自習書は個人が自主的に無償で公開・提供するものであり、サポートはありません。

本自習書に関して、質問や連絡事項などある場合は、本 GitHub リポジトリの [Issue](https://github.com/jsakamoto/self-learning-materials-for-blazor-jp/issues) を利用ください。


関連リソース
----------------------------------------

- Blazor 公式 GitHub リポジトリ - [https://github.com/aspnet/AspNetCore/tree/master/src/Components](https://github.com/aspnet/AspNetCore/tree/master/src/Components)
- Blazor 公式サイト - [https://blazor.net/](https://blazor.net/)
    - "Get started with Blazor" - [https://blazor.net/docs/get-started.html](https://blazor.net/docs/get-started.html)
- Blazor 学習サイト(英語) "Learn Blazor" - [https://learn-blazor.com/](https://learn-blazor.com/)
