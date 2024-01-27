using System.Reflection;

namespace EfcoreSQLiteApp.Views
{
    public partial class MainPage(MainPageViewModel viewModel) : BasePage<MainPageViewModel>(viewModel, "Main Page")
    {
        public override void Build()
        {
            var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

            this
                .ContentFmg(
                    new ScrollView()
                    .ContentFmg(
                        new Grid()
                        .RowDefinitionsFmg(e => e.Star(90).Star(10))
                        .ChildrenFmg(
                            new StackLayout()
                            .SpacingFmg(25)
                            .ChildrenFmg(
                                new Label()
                                .TextFmg("Hello, World!")
                                .FontSizeFmg(32)
                                .CenterHorizontalFmg()
                                .SemanticHeadingLevelFmg(SemanticHeadingLevel.Level1),

                                new Label()
                                .TextFmg("Welcome to .NET Multi-platform App UI")
                                .FontSizeFmg(18)
                                .CenterHorizontalFmg()
                                .SemanticDescriptionFmg("Welcome to dot net Multi platform App U I")
                                .SemanticHeadingLevelFmg(SemanticHeadingLevel.Level1),

                                new Label()
                                .TextFmg("Current count: 0")
                                .FontSizeFmg(18)
                                .FontAttributesFmg(FontAttributes.Bold)
                                .CenterHorizontalFmg()
                                .AssignFmg(out CounterLabel),

                                new Button()
                                .TextFmg("Click me")
                                .CenterHorizontalFmg()
                                .InvokeOnElementFmg(btn => btn.Clicked += OnCounterClicked)
                                .SemanticHintFmg("Counts the number of times you click"),

                                new Image()
                                .SourceFmg("dotnet_bot.png")
                                .WidthRequestFmg(250)
                                .HeightRequestFmg(310)
                                .CenterHorizontalFmg()
                                .SemanticDescriptionFmg("Cute dot net bot waving hi to you!")
                            ),

                            new Grid()
                            .BackgroundColorFmg(AppColors.Primary)
                            .RowFmg(1)
                            .ChildrenFmg(
                                new Label()
                                .TextFmg($"dotNet version: {version}")
                                .TextColorFmg(White)
                                .CenterFmg()
                            )
                        )
                    )

                );
        }

        private int _count = 0;
        private Label CounterLabel;


        private void OnCounterClicked(object? sender, EventArgs e)
        {
            _count++;
            CounterLabel.Text = $"Current count: {_count}";

            SemanticScreenReader.Announce(CounterLabel.Text);
        }
    }
}
