namespace EfcoreSQLiteApp.Views;

public partial class LoginPage(LoginPageViewModel viewModel) : BasePage<LoginPageViewModel>(viewModel, "Login")
{
    public override void Build()
    {
        this
        .ContentFmg(
            new Grid()
            .RowDefinitionsFmg(x => x.Star(3).Star(5).Star(3))
            .PaddingFmg(10)
            .MarginFmg(10)
            .ChildrenFmg(
                new Frame()
                .RowFmg(1)
                .CornerRadiusFmg(25)
                .BackgroundColorFmg(DarkGray)
                .BorderColorFmg(DarkGray)
                .PaddingFmg(10)
                .ContentFmg(
                    new VerticalStackLayout()
                    .SpacingFmg(10)
                    .ChildrenFmg(
                        new Entry()
                        .PlaceholderFmg("Mail adresi gir.")
                        .BindFmg(Entry.TextProperty, nameof(BindingContext.Email)),

                        new Entry()
                        .PlaceholderFmg("Şifreni gir.")
                        .BindFmg(Entry.TextProperty, nameof(BindingContext.Password)),

                        new Button()
                        .TextFmg("Giriş Yap")
                        .FontSizeFmg(15)
                        .FontAttributesFmg(FontAttributes.Bold)
                        .CommandFmg(BindingContext.LoginCommand)
                    )
                )
            )
        );
    }
}
