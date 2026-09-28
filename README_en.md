This project provides four basic function modifications for Touhou Project (Integer). Currently, it only includes basic functions such as lock residual, lock bomb, full energy, lock energy, invincibility, etc. Of course, it is not limited to this. Subsequent functions are still under development, so stay tuned. Welcome to submit PR or Issues Of course you can also give a Star

Written in C#, the function is realized by external R/W of application memory. Supports Chinese/English/Japanese languages. All languages ​​except Chinese are machine translated. Use Visual Studio 2022 Preview and WPF for development. DONET version is 8.0

DONET 8.0 runtime must be installed before using the non-independent version. Download address: <https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0>

Known issues: none. "Max Power" for TH07 Touhou Youyoumu and TH08 Touhou Eiyashou is now implemented (targets TH07 v1.00b / TH08 v1.00d respectively); please file an issue if anything goes wrong.

Download address: Github Release

TH06 Touhou Koumakyou: Supported

TH06 Touhou Koumakyou: New Classic: Supported

TH07 Touhou Youyoumu: Supported

TH08 Touhou Eiyashou: Supported

TH09 Touhou Kaeizuka: Supported — Invincible / Lock Rank / Allow Multiple Instances

TH10 Touhou Fuujinroku: Supported

TH11 Touhou Chireiden: Supported

TH12 Touhou Seirensen: Supported

TH13 Touhou Shinreibyou: Supported

TH14 Touhou Kishinjou: Supported

TH15 Touhou Kanjuden: Supported

TH16 Touhou Tenkuushou: Supported

TH17 Touhou Kikeijuu: Supported

TH18 Touhou Kouryuudou: Supported

TH19 Touhou Juuouen: Supported — Lock Player / Invincible / Lock CPU Charge

TH20 Touhou Kinjoukyou: Supported

---

Three caveats: **each patch table targets one exact exe version** (its timeStamp and textSize are recorded in that file) — before enabling any toggle the program reads the PE header of the running exe and refuses to write when the version does not match, showing a hint on the page instead. Juuouen ships as two exe versions (v1.00a / v1.10c) with different offsets; the matching set is picked automatically. And each page only lists the mechanics that title actually has — no dead toggles.

Touhou Koumakyou: New Classic is the 2026 standalone remake. Its process name is th06nc and it is a different executable from the original Koumakyou above, so the two are modified independently. It is a 64-bit program: use the x64 build of this tool (the 32-bit build cannot read its module base, and the toggles will not turn on).

The 7 titles below (versus/fighting spinoffs) are not wired up yet: candidate offsets have been obtained for four of them but none are entered into the program, and the other three have none available. Their toggles are disabled (greyed out) and no write is ever made to the game process.

TH07.5 Touhou Suimusou (th075): Scaffolding ready (candidate offsets obtained, not wired yet)

TH09.5 Touhou Bunkachou (th095): Supported — Invincible / Inf. Charge / Coercive Reporting / Time Lock

TH10.5 Touhou Hisouten (th105): Scaffolding ready (offsets pending)

TH12.3 Touhou Hisoutensoku (th123): Scaffolding ready (candidate offsets obtained, not wired yet)

TH12.5 Double Spoiler (th125): Supported — Invincible / Inf. Charge / Coercive Reporting / Time Lock

TH12.8 Great Fairy Wars (th128): Supported — Invincible / Lock Player / Lock Bomb / Max Power / Time Lock / Auto Bomb

TH13.5 Touhou Shinkirou (th135): Scaffolding ready (offsets pending)

TH14.3 Danmaku Amanojaku (th143): Supported — Invincible / Inf. Items / Time Lock

TH14.5 Touhou Shinpiroku (th145): Scaffolding ready (offsets pending)

TH15.5 Touhou Hyouika (th155): Scaffolding ready (candidate offsets obtained, not wired yet)

TH16.5 Hifuu Nightmare Diary (th165): Supported — Invincible / Inf. Charge / Time Lock

TH17.5 Touhou Gouyoku Ibun (th175): Scaffolding ready (candidate offsets obtained, not wired yet)

TH18.5 100th Black Market (th185): Supported — Invincible / Lock Player / Inf. BMoney / Time Lock

If the game is not detected, rename the game executable to th (followed by the title number). For example, Touhou Seirensen is th12c/th12 and Touhou Koumakyou is th06/th06c. Also start the game first and wait until the red dot at the top-right of the matching cover in this tool turns green — only then can the toggles be used.
