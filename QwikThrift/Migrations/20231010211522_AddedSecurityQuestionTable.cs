using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QwikThrift.Migrations
{
    public partial class AddedSecurityQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerSalt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecurityQuestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 10, 17, 15, 22, 515, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "컛槺馱㫷ꋵ쯯皢펌㫬뵉臅ꄝ䞭璥₷௃忳哮辶侼ꯘ쑣௷Ṵតﰭ", "[gx`m#gtZW}m-'994:lT{q9zA4i%Bv(0*Lw$BL@AV3G/M`MuS-Ho'dzs<}_cr9I_s+UH]tVMj;XJZz3rJZE|A<M0\\3zIb_kFk[pbl_J]?^:3,>Y7X368,o2U{nD<i=U\\*Y4zXvuC4uvId3,.OrVZCjdb:zXoet-c]COY?IPtEE7`H94<[<>J?odzWOa#+g4`rx%rWNqP[g;|PbzkF?qpEF'*wj,#6.QSTq,&HMg:]?$+a#x2Ybp#S\\$g;%zx0bVb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "㽂ํᇁﷷὉ撒忄좴휉搝恥盗丅癈奸䣂ﷰ⧦傋墏ꔍ錱꠨��Ņ빯検", "<r>ZU[piQE-}BCCf='q?hX;z{`Maa.$Vy$0.#39AH*+{]F.f)7ye-|R8Ha[y#,@kr_C\\1)qg__tL>Gq^HB;{,bD#b-I.'^RNPy.b=c5W,]zf|aZjDG|,SS20WlHOu:Au4OZ@\\3p+=s8e=3kA+tG)=Q3PlPnLFb7MzRSFLkG\\=`P,_cALy6+Ua0@1'mOt#-#rzVG:4K=`+4m.MIChJH[8dpSb*3qf;7(;7w,ScYgW+5f)f.BR#_cy?D[q*Y9?v'nW" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "⎑ӻ楶䀅욾鑞৽Ƅ❦腩鹅诸鼀켭徘Ᏻ뎝㬤촷쁠讨⸮㝭ﲴ踬堛胢쿓", "fiXFDenA8Nm;q/4*+O6BZ:\\&QhR@ZuYCh=+/yO\\>IzNe0QZ*>U1[p|7yW%?6F$C4tIYyLG.f8XRWIjN(br0&JCvf9/v#vEz+`_hZ|&+cOtt'(`Vrkl_BK@<D|,kTm5FotI,a#89Oa'+okJj6OMh/m0#7[06'2@`?uZ$i>vVM?$nP:n6l\\%^4yaIkmA?^ipbe.RRHw&PSZ%+wIV_&3&Y-.cKWQP>_-=zMd\\kb0{-`h]0)ou|^Fbu2]*e.3v@4wHSv" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ផࡪ㨉䙱ㆼ㶍儾瓆ᩏჃ亟⒄╓覬뮸蟈ヶﳌ鳪防軷걆잹肮려✽Ꮈㄏ촒눹", "j?w|2$$XC4T2I(#9upFw^S8]Y28}w6davzmng$@Df#+k30NL##n,Hf:^LbMl:jsD2eLluba'(@)i;(EBV4A``c4uAq$l19PP=jj@M&Ig|kB#I<x|jAUs@u/?3./FBf#Ja$\\ETPa8L,NzWh5*xV346Whh1i(d2sX\\y7=n?&-+M|4s94sw@8aU<g}S&h#.*5CzCFiDUQX&cZ`Zp]5=y4/S[8P595QM%8Q_z\\p@]+vF^u@yJO_j:Y}2iCB-c378&zX6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "恲켂⦴礓糊䍃ꅃ뇧⒄ꅡ�Ⰺு毻⪑뙪崲녶헡㮙伀钞肢ㄳꇢۊ�梪", "*QW5DAT293/Nw[v4wEB`U:)'8p?E$1d,I%C?J>uitfYRo\\^p5?I*i*U]_W)x1;iHWO(T6qK;V)^L:3ED*}:au^v'DqWHgI5o[I)bj/p_(+Z(/s9d>Rv8@Sgm67R^0p(XI(1>Q8=@^p@<3#+Ly^{S@8@9%T{.rJqYO[3OCxNE:2JLIG9#UcCCNiuvU+]wI#Skk93w6ba&FM=2-{a;K0NfF)K/;C/A%\\Ze?dbZdCh>_3xNbfW}_e.MJif`X#|)dy{?" });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_UserId",
                table: "SecurityQuestions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityQuestions");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 9, 19, 23, 55, 320, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ぬ녆쓳虄긲췔硬궈䥎氩䙆鐾䥚㘻몶㘨ᑇꇺ밗‬ሑ須⫶䕃靏瓦욾뮅꣐쿂", "y/a7L$Z}k{X[+_8iZsPSQO4;a-&GnWb,+{^xw1#)&Ui8K9ZklSPRMy57<U&)LbFqIEJ|M>A5V</e5q==QVFT`fym2$sok)DYP56k+@0K|XDrrJ]xo4hKgNo|x+*`[G@<]PedP|q[[GNXu6jlF;o[,^HrU[325IuF3s}wrjJ&7SHI/IOoMWb97-rxCjz.+S^@%c|ov(fCZu@VvCTv`|?V2}0#K%dJD&6>@8#R4D5Att-KLmF&LaQwj@Ng2yC.3Q7T" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "卲ੇ᝭袴厉ﬅ⏫돺溺୥腢ꏥꥯ丛羇𥳐⹀㴸蜨笆蒇볘먯䷍�⯕짳뻞곧䭃⟊", "3)Y;;z&w:%1+ej[ryQ<#M}PO))[x<p@^:b:Rh/;wL_M'S3&ehys8}vsWUF:oQ'Lc`jD[|Ll/NR\\,(F]>gxcQ6FABu8y8q/\\El\\ic_3%{AL319ce6V+-_FfpvT0I4fS#XV1EkApApSP@`NN^29=}wXV(m}1h7F#DH>Q6e}c+vvo5?TbHWam5dr_@JsQ2rfd^\\]au]<bwl?k5/75p0XgoZ9\\ses,]4,hrsP`,HRgP.hShw'Pn[-<l`R,[36Z5Bu=e\\" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "얫Ꞿ�㻔Ҹ㼗ᖣ鵍뗵布㜄䟠랢册ꆔ颋盧큓ͺ糶彄궘ﵧ঎⁾쀢捶루ꡔ", "MKT#O[0#suBI1KN:BkduxR/sBTQ)xg#J9<@pcwSk.YcSJ/i|\\<rC}A_H_cRIswY|\\)?w3OiNt(lV[:C@$.o@Pno?|$OKVcYQ+3qt=G]4W$KUnzp6AfHj>?1zg%82FSi?#@g+z$*Z%_f7g,Wvbc=cF%$x+%W2tv&&rpEi>tFd^xUTAB={SQHr{owm58LH'\\>P-C,rL?%vt<[:D-vrZp5WGu:$d]^}v*_M5ZcQ'C1|^T8MN=s5Jth:SlF1HC-Sn)U)" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "憢⢯钗郩ꍺᛪ忄졒鷁ॢ웵驑私鶂߭溼蘮龱쎶湸蜐ꪌ䰽�鋚巅ᘘ㻵맀", "-2><d:vu0es:oF{$@lGz{b1Xs@Pl_Jg,aR\\rziv/RE=q*HFUt}KC^QSk&SRJ.3j478BMfDy/8qV(e^WiI//Ma2Gw\\;&P:Ib_cm8&#nhu,'K7|'S:$A+8_#LqX&Q&,k03D_e^1B%><dPsmNCKNO`v%%`I8UD(rU]}a'xN[zp//<S{K1&IR&ZP)F`-+*6(porA#X3SI>yU.3*FYD#zgkN6Bih:fH70Z_9]vey(EVr[OvZ#{)3{QU$.j`:z<0jtw2&Z" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "臨꼅㪜쉊ꏫ�닾쌝�￯줠傼釦魒嶳竻跡遛곴⬊⮬�ꊺᲡ网廳浥뼇闺㖊", "=2v31(@T(0<B:p<E#xaCM|SI;CBNZafE_`r\\<BTqI5C=1_3[y42MK9fB#*gt#:`S8N9U/-Kx',WN-{SoZtlTHq)lZd{`d8[eI>Q`9y.W@5E&bE.Xu-<}mrW6ZLxvu#3bWTPBkaE/G10wE&qB;L(`Yf`@}-$T|Sg4j9<\\UXi*]AD\\TKWUyflIkRB%+*g?vn91@z)z](c:NF1F\\+VDtfZ:m0g'Sd;xO|yK<e]/={%](B%zkaW+z;,clQ\\bqa,?)|:7" });
        }
    }
}
