using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Touhou_Project_Mod_UI.Models;
using Touhou_Project_Mod_UI.SDK.Native;
using Res = Touhou_Project_Mod_UI.Properties.Resources;

namespace Touhou_Project_Mod_UI.Views
{
    public abstract class TouhouHackPage : Page, INotifyPropertyChanged
    {
        private static readonly Brush RunningBrush = new SolidColorBrush(Color.FromRgb(0x22, 0xC5, 0x5E));
        private static readonly Brush StoppedBrush = new SolidColorBrush(Color.FromRgb(0xEF, 0x44, 0x44));
        private static readonly Brush HintBrush = new SolidColorBrush(Color.FromRgb(0x88, 0x88, 0x88));

        private readonly GameProfile[] _variants;

        private readonly Ellipse _statusDot;
        private readonly TextBlock _versionHint;

        private GameProfile _profile;

        private bool _versionResolved;

        private bool _versionMismatch;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected TouhouHackPage(params GameProfile[] variants)
        {
            if (variants == null || variants.Length == 0)
            {
                throw new ArgumentException("至少需要一个 profile。", nameof(variants));
            }

            _variants = variants;
            _profile = variants[0];

            DataContext = this;
            Content = BuildContent(out _statusDot, out _versionHint);
            UpdateStatusDot();
            UpdateVersionHint();

            Status status = _variants[0].Status;

            status.IsTouhouRunChanged += OnStatusChanged;
            status.LockPlayerChanged += OnStatusChanged;
            status.LockBombChanged += OnStatusChanged;
            status.MaxPowerChanged += OnStatusChanged;
            status.InvincibleChanged += OnStatusChanged;
            status.FeatureChanged += OnFeatureChanged;
        }

        private Status Status => _variants[0].Status;

        private void OnStatusChanged(object? sender, EventArgs e)
        {
            if (!Status.IsRun)
            {
                _versionResolved = false;
                _versionMismatch = false;
                _profile = _variants[0];
            }

            RunOnUiThread(() =>
            {
                UpdateStatusDot();
                UpdateVersionHint();
            });

            OnPropertyChanged(nameof(IsGreenDotVisible));
            OnPropertyChanged(nameof(LockPlayer));
            OnPropertyChanged(nameof(LockBomb));
            OnPropertyChanged(nameof(MaxPower));
            OnPropertyChanged(nameof(Invincible));
        }

        private void OnFeatureChanged(object? sender, HackFeature feature)
        {
            OnPropertyChanged(feature.ToString());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RunOnUiThread(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                action();
                return;
            }

            if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            {
                return;
            }

            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, action);
        }

        public bool IsGreenDotVisible => Status.IsRun;

        #region 开关状态（属性名必须与 HackFeature 成员同名，绑定路径直接用枚举名）

        public bool LockPlayer
        {
            get => Status.LockPlayer;
            set => Status.LockPlayer = value;
        }

        public bool LockBomb
        {
            get => Status.LockBomb;
            set => Status.LockBomb = value;
        }

        public bool MaxPower
        {
            get => Status.MaxPower;
            set => Status.MaxPower = value;
        }

        public bool Invincible
        {
            get => Status.Invincible;
            set => Status.Invincible = value;
        }

        public bool LockTime
        {
            get => Status.GetFeature(HackFeature.LockTime);
            set => Status.SetFeature(HackFeature.LockTime, value);
        }

        public bool InfCharge
        {
            get => Status.GetFeature(HackFeature.InfCharge);
            set => Status.SetFeature(HackFeature.InfCharge, value);
        }

        public bool FocusLockOn
        {
            get => Status.GetFeature(HackFeature.FocusLockOn);
            set => Status.SetFeature(HackFeature.FocusLockOn, value);
        }

        public bool InfItems
        {
            get => Status.GetFeature(HackFeature.InfItems);
            set => Status.SetFeature(HackFeature.InfItems, value);
        }

        public bool InfBMoney
        {
            get => Status.GetFeature(HackFeature.InfBMoney);
            set => Status.SetFeature(HackFeature.InfBMoney, value);
        }

        public bool AutoBomb
        {
            get => Status.GetFeature(HackFeature.AutoBomb);
            set => Status.SetFeature(HackFeature.AutoBomb, value);
        }

        public bool LockRank
        {
            get => Status.GetFeature(HackFeature.LockRank);
            set => Status.SetFeature(HackFeature.LockRank, value);
        }

        public bool CpuChargeLock
        {
            get => Status.GetFeature(HackFeature.CpuChargeLock);
            set => Status.SetFeature(HackFeature.CpuChargeLock, value);
        }

        public bool MultiInstance
        {
            get => Status.GetFeature(HackFeature.MultiInstance);
            set => Status.SetFeature(HackFeature.MultiInstance, value);
        }

        #endregion

        #region 界面构建

        private UIElement BuildContent(out Ellipse statusDot, out TextBlock versionHint)
        {
            Grid root = new Grid();
            root.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            root.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            Grid coverHost = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            coverHost.Children.Add(new Image
            {
                Width = 200,
                Height = 200,
                Source = LoadCover(_profile.CoverImage),
            });

            statusDot = new Ellipse
            {
                Width = 15,
                Height = 15,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 5, 5, 0),
            };
            coverHost.Children.Add(statusDot);

            Grid.SetRow(coverHost, 0);
            root.Children.Add(coverHost);

            versionHint = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                FontSize = 12,
                Margin = new Thickness(12, 0, 12, 0),
            };

            Grid.SetRow(versionHint, 1);
            root.Children.Add(versionHint);

            UniformGrid toggles = new UniformGrid
            {
                Columns = 2,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 20, 0, 0),
            };

            foreach (FeaturePatch feature in _profile.Features)
            {
                toggles.Children.Add(BuildToggle(feature.Feature));
            }

            Grid.SetRow(toggles, 2);
            root.Children.Add(toggles);

            return root;
        }

        private static BitmapImage LoadCover(string resourcePath)
        {
            string assemblyName = typeof(TouhouHackPage).Assembly.GetName().Name ?? string.Empty;
            Uri uri = new Uri("pack://application:,,,/" + assemblyName + ";component" + resourcePath, UriKind.Absolute);
            return new BitmapImage(uri);
        }

        private ModernWpf.Controls.ToggleSwitch BuildToggle(HackFeature feature)
        {
            ModernWpf.Controls.ToggleSwitch toggle = new ModernWpf.Controls.ToggleSwitch
            {
                Name = feature + "Switch",
                Header = HeaderText(feature),
                OffContent = Res.Disabled,
                OnContent = Res.Enabled,
                Margin = new Thickness(10),
            };

            toggle.SetBinding(ModernWpf.Controls.ToggleSwitch.IsOnProperty,
                new System.Windows.Data.Binding(feature.ToString())
                {
                    Source = this,
                    Mode = System.Windows.Data.BindingMode.TwoWay,
                });

            toggle.Toggled += (sender, e) => OnToggle(feature);

            return toggle;
        }

        private static string HeaderText(HackFeature feature)
        {
            switch (feature)
            {
                case HackFeature.LockPlayer: return Res.LockPlayer;
                case HackFeature.LockBomb: return Res.LockBomb;
                case HackFeature.MaxPower: return Res.MaxPower;
                case HackFeature.Invincible: return Res.Invincible;
                case HackFeature.LockTime: return Res.LockTime;
                case HackFeature.InfCharge: return Res.InfCharge;
                case HackFeature.FocusLockOn: return Res.FocusLockOn;
                case HackFeature.InfItems: return Res.InfItems;
                case HackFeature.InfBMoney: return Res.InfBMoney;
                case HackFeature.AutoBomb: return Res.AutoBomb;
                case HackFeature.LockRank: return Res.LockRank;
                case HackFeature.CpuChargeLock: return Res.CpuChargeLock;
                case HackFeature.MultiInstance: return Res.MultiInstance;
                default: return feature.ToString();
            }
        }

        private void UpdateStatusDot()
        {
            _statusDot.Fill = IsGreenDotVisible ? RunningBrush : StoppedBrush;
        }

        private void UpdateVersionHint()
        {
            if (!Status.IsRun)
            {
                _versionHint.Text = string.Empty;
                return;
            }

            if (_versionMismatch)
            {
                _versionHint.Text = Res.VersionMismatch + " · " + _variants[0].SourceNote;
                _versionHint.Foreground = StoppedBrush;
                return;
            }

            _versionHint.Text = _profile.SourceNote;
            _versionHint.Foreground = HintBrush;
        }

        #endregion

        #region 版本核对

        private bool ResolveByExeVersion()
        {
            if (_versionResolved)
            {
                return true;
            }

            bool anyIdentityDeclared = false;
            foreach (GameProfile variant in _variants)
            {
                if (variant.HasVersionIdentity)
                {
                    anyIdentityDeclared = true;
                    break;
                }
            }

            if (!anyIdentityDeclared)
            {
                _versionResolved = true;
                return true;
            }

            if (!ExeVersion.TryRead(Status.ProcessHandle, Status.BaseAddress, out uint timeStamp, out uint textSize))
            {
                _versionMismatch = true;
                return false;
            }

            foreach (GameProfile variant in _variants)
            {
                if (variant.MatchesVersion(timeStamp, textSize))
                {
                    _profile = variant;
                    _versionResolved = true;
                    _versionMismatch = false;
                    UpdateVersionHint();
                    return true;
                }
            }

            _versionMismatch = true;
            return false;
        }

        #endregion

        #region 开关处理

        private void OnToggle(HackFeature feature)
        {
            if (Status.GetLocker(feature))
            {
                Status.SetLocker(feature, false);
                return;
            }

            if (!Status.IsRun)
            {
                Revert(feature);
                return;
            }

            if (Status.BaseAddress == IntPtr.Zero && Status.ProcessHandle == IntPtr.Zero && !AcquireMemory())
            {
                Revert(feature);
                return;
            }

            if (!ResolveByExeVersion())
            {
                Revert(feature);
                UpdateVersionHint();
                return;
            }

            CodePatch[]? patches = FindPatches(feature);
            bool enable = Status.GetFeature(feature);

            if (patches == null || !Patcher.Apply(Status.ProcessHandle, Status.BaseAddress, patches, enable))
            {
                Revert(feature);
            }
        }

        private void Revert(HackFeature feature)
        {
            Status.SetLocker(feature, true);
            Status.SetFeature(feature, false);
        }

        private CodePatch[]? FindPatches(HackFeature feature)
        {
            foreach (FeaturePatch item in _profile.Features)
            {
                if (item.Feature == feature)
                {
                    return item.Patches;
                }
            }
            return null;
        }

        private bool AcquireMemory()
        {
            foreach (string processName in _profile.ProcessNames)
            {
                (Status.BaseAddress, Status.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle(processName);
                if (Status.BaseAddress != IntPtr.Zero && Status.ProcessHandle != IntPtr.Zero)
                {
                    return true;
                }
            }

            Status.BaseAddress = IntPtr.Zero;
            Status.ProcessHandle = IntPtr.Zero;
            return false;
        }

        #endregion
    }
}
