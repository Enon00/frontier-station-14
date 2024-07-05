using Content.Shared.Chemistry;
using Robust.Client.AutoGenerated;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Chemistry.UI;

[GenerateTypedNameReferences]
public sealed partial class ReagentCardControl : Control
{
    public string StorageSlotId { get; }
    public Action<string>? OnPressed;
    public Action<string>? OnEjectButtonPressed;

    public ReagentCardControl(ReagentInventoryItem item)
    {
        RobustXamlLoader.Load(this);

        StorageSlotId = item.StorageSlotId;
        ColorPanel.PanelOverride = new StyleBoxFlat { BackgroundColor = item.ReagentColor };
        ReagentNameLabel.Text = item.ReagentLabel;
        FillLabel.Text = Loc.GetString("reagent-dispenser-window-quantity-label-text", ("quantity", item.Quantity));;
        EjectButtonIcon.Text = Loc.GetString("reagent-dispenser-window-eject-container-button");

        if (item.Quantity == 0.0)
            MainButton.Disabled = true;

        MainButton.OnPressed += args => OnPressed?.Invoke(StorageSlotId);
        EjectButton.OnPressed += args => OnEjectButtonPressed?.Invoke(StorageSlotId);
    }
}