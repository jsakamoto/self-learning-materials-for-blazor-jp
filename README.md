
📖 Blazor WebAssembly アプリケーションプログラミング自習書
============================================

🗨️ 概要
----------------------------------------

まずタイトルにある **"Blazor (ブレイザー)"** ですが、これは、**C# 言語を用いて (Single Page Application (SPA) を含めた) Web アプリケーションを開発、実行**する、フレームワーク/実行環境/開発環境です。

本書が対象としている Blazor WebAssembly では、C# ソースコードを **JavaScript に変換するのではなく**、Web ブラウザの **WebAssembly 上に構築された .NET 実行環境が .NET アセンブリ (.dll) をそのまま読み込み、アセンブリ 内の IL (中間言語) を解釈・実行**します。

本書は、題目の Web アプリケーションを Blazor WebAssembly で開発する手順を1ステップずつ解説し、  
「Blazor WebAssembly のプログラミングってどんな感じなの?」  
「Blazor ってどこがメリットなの?」  
といった疑問にお答えできることを狙いとした、Blazor についての事前評価ができるような、そんな入門レベルの自習書テキストです。

なお、本書が対象としている Blazor のバージョンは v.8.0 です。  
(GitHub リポジトリには、本書の旧バージョン対応版も履歴に含まれています)


🚀 本書で開発する Web アプリ
----------------------------------------

本書では、ページ上に複数のタイムゾーンの現在時刻を一斉表示する「世界時計」 Web アプリを Blazor WebAssembly を使って実装します。  
表示する時計の表示用の名称とタイムゾーンを、追加、変更、削除するページを備えます。

![fig.1](.assets/fig.001.png)

下記 URL で完成版を公開しています。

- https://jsakamoto.github.io/self-learning-materials-for-blazor-jp/


📖 自習書テキストとソースコード
----------------------------------------

自習書テキストは PDF ファイルとして提供しており、下記リンクから参照できます。

- [📒 Blazorアプリケーションプログラミング自習書-v.8.0.0.pdf](https://jsakamoto.github.io/self-learning-materials-for-blazor-jp/Blazor%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0%E8%87%AA%E7%BF%92%E6%9B%B8-v.8.0.0.pdf)

この自習書テキストに沿って作業を進めることで、**Blazor WebAssembly プログラミングの主だった構成要素を習得・体験**しつつ、**IDE 支援がどのように役立つか**も体験することができます。

また、本リポジトリの [v.8.0.0 ブランチ](https://github.com/jsakamoto/self-learning-materials-for-blazor-jp/commits/v.8.0.0)には、自習書テキストで解説している 1 ステップを 1 コミットとして履歴を記録したソースコードが収録されています。  
適宜ご参照ください。

なお、自習書テキスト PDF および 1 ステップごとのソースコードを収録した Zip ファイルを、[GitHub リポジトリの Release ページ](https://github.com/jsakamoto/self-learning-materials-for-blazor-jp/releases)からダウンロードできます。  

本格的に本自習書に取り組んでみる際は、**上記 Release ページで配付している Zip ファイルを入手して開始されるのがお勧め**です。


👪 想定する本自習書の利用者層
----------------------------------------

本自習書では、サーバー側実装として ASP.NET Core を採用しています。  
また Blazor は基本的にプログラミング言語は C# が想定されています。

そのため、本自習書では下記のような開発者を想定しております。

- HTML/CSS/JavaScript を用いた Web アプリケーション開発の知識がある
- C# によるプログラミングの知識がある
- 加えて ASP.NET Core によるサーバーサイド Web アプリケーション開発の知識があるとなお可

> ※ Angular, React, Vue などといった JavaScript SPA フレームワークの知識・経験は必ずしも必要としないことと考えていますが、もし何かしら SPA フレームワークの知識・経験があれば、Blazor の理解にも役立つと思います。


🛠️ 必要な開発環境
----------------------------------------

### 必須環境

本稿執筆時点で、本自習書による Blazor 開発を実践するにあたり、最低限必要な開発環境は下記のとおりです。

- [.NET 8.0 SDK (8.0.100 かそれ以降)](https://dotnet.microsoft.com/download/dotnet-core/8.0)
- 上記 SDK が対応しているデスクトップ OS (Windows, macOS, 各種 Linux ディストリビューション)
- 何らかのテキストエディタ/コードエディタ
- インターネット接続
- Micorosoft Edge, Google Chrome, Mozilla Firefox, Safari などの近代的な Web ブラウザ

以上の環境があれば、テキストエディタでソースコードを記述し、`dotnet` コマンドをターミナル (コマンドプロンプト) 上から実行することで、Blazor アプリケーションの実装・ビルド・実行が可能です。以下ではさらに、上記に加えて Blazor アプリケーション開発をより快適に行うための開発環境について記載します。

### もっとも手軽な方法 - GitHub Codespaces を使う

[GitHub Codespaces](https://github.co.jp/features/codespaces) は、クラウド上の Linux 仮想マシンに構築された開発環境を、Web ブラウザで動作する Visual Studio Code 相当のコードエディタを介して利用できる、GitHub が提供するサービスです。インターネット接続と Web ブラウザ、それに GitHub アカウントさえあれば、Web ブラウザだけで本自習書による Blazor アプリケーション開発を実践できます。

下記リンクをクリックすると、.NET SDK のインストールも既に済んでいる、本自習書のステップ 1 の GitHub Codespaces による開発環境が Web ブラウザで開きます。

[![GitHub Codespaces で開く](https://github.com/codespaces/badge.svg)](https://github.com/codespaces/new/jsakamoto/self-learning-materials-for-blazor-jp/tree/boilerplate%2Fv.8.0.0?quickstart=1)

詳細は[自習書テキスト PDF](https://jsakamoto.github.io/self-learning-materials-for-blazor-jp/Blazor%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0%E8%87%AA%E7%BF%92%E6%9B%B8-v.8.0.0.pdf) の「開発環境」の章をご参照ください。

> [!NOTE]  
> GitHub Codespaces は最長 60 分/月の無料枠がある有償サービスです。料金体系について詳しくは[公式サイト](https://github.co.jp/features/codespaces)を参照ください。

### Visual Studio Code を使う

手元のローカル PC 上に、.NET SDK をインストールして開発作業を行なう場合は、**Visual Studio Code** の利用をお勧めします。特に、**C# および C# Dev Kit** の Visual Studio Code 拡張を追加しての利用が推奨されます。これら拡張がインストールされていれば、構文ハイライトやインテリセンスをはじめとした、強力な開発支援が得られます。

- [Visual Studio Code](https://code.visualstudio.com/)
- [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
- [C# Dev Kit for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

> [!NOTE]  
> C# Dev Kit 拡張の利用にあたっては、Visual Studio 相当の使用条件があります。

### Windows 上で Visual Studio 2022 を使う

Windows PC をお使いの場合は、統合開発環境である Visual Studio の使用もお勧めです。

- [Visual Studio 2022 - 17.8.0 以降](https://visualstudio.microsoft.com/vs/)
    - "ASP.NET と Web 開発" ワークロードが選択されていること

> [!NOTE]  
> ※1 - Visual Studio 2022 は、無償利用可能な (但しライセンス条項に違反しない場合) Community Edition で可。  
> ※2 - Visual Studio は、複数のバージョンやインスタンスを、ひとつの OS 上に互いの干渉なくいくつもインストールして使用することが可能です。

 🤔 自習書作成の背景
----------------------------------------

Blazor は、SPA を含めた各種 Web アプリケーション開発のシーンにおいて、もちろん決して ["銀の弾丸"](https://kotobank.jp/word/%E9%8A%80%E3%81%AE%E5%BC%BE%E4%B8%B8-248402) ではありません。  
しかしながら Blazor は、適合する案件や開発者であれば、**開発の負担を減らし、よりよい生産性向上をもたらす可能性**を秘めています。

そこでこの Blazor の可能性をより多くの開発者に体験していただき、Blazor WebAssembly を事前評価していただければと考え、この「Blazor WebAssembly アプリケーションプログラミング自習書 (自習教材)」を作成しました。


📣 ライセンス
----------------------------------------

本 GitHub リポジトリに含まれる自習書テキスト、及び、ソースコードは、[The Unlicense](LICENSE) として提供します。

商用・非商用に関係なく、また、クレジット表示も不要で、本リポジトリに含まれるテキストやソースコードを再利用・改変・再配布が可能です。


📩 サポート
----------------------------------------

本自習書は個人が自主的に無償で公開・提供するものであり、サポートはありません。

本自習書に関して、質問や連絡事項などある場合は、本 GitHub リポジトリの [Issue](https://github.com/jsakamoto/self-learning-materials-for-blazor-jp/issues) を利用ください。


🔗 関連リソース
----------------------------------------

- Blazor 公式 GitHub リポジトリ - [https://github.com/aspnet/AspNetCore/tree/master/src/Components](https://github.com/aspnet/AspNetCore/tree/master/src/Components)
- Blazor 公式サイト - [https://blazor.net/](https://blazor.net/)
    - Blazor チュートリアル - [https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/](https://dotnet.microsoft.com/ja-jp/learn/aspnet/blazor-tutorial/)
- Blazor 関連リンク集 (英語) "Awesome Blazor" - [https://github.com/AdrienTorris/awesomeblazor](https://github.com/AdrienTorris/awesomeblazor#awesome-blazor-) 
