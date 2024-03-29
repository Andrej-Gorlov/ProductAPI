﻿namespace ProductAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Лесные" });//ImageUrl= "https://lh3.googleusercontent.com/pw/AL9nZEXC8RTHNq45D41a10x-3m7eT51aKD5CboKhjtpxD6bxeCBm-U8deZH0q__eH15H79LzRiaNxrQ-Aw-XPFk69ldrRo3Di52wmSJaWvHJE2Qip-VzggFNpVQtl6UZfHRr__DMV8Ed9ktNlHaHj2ahzUuQ=w1300-h800-no?authuser=0" });
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 2, CategoryName = "Комнатные" });//, ImageUrl = "https://lh3.googleusercontent.com/pw/AL9nZEWLihDEBnTHWHZ7SQOCO2fQh4sHhCYW6CLNtyE0wgc2G7HP4uQULTNWrFBv_sPKTY9i3_oyDv46wiq-5gFfDsdnq7HIstPTXES0X-y_NS2Q-xJ4VLPj1Jy67Mv_YKCGKaKy6-RbA7a1IWYKsvLVINw6=w1300-h800-no?authuser=0" });
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 3, CategoryName = "Лекарственный" });//, ImageUrl = "https://lh3.googleusercontent.com/pw/AL9nZEWW7tOMg9dCobwWSgLd1HxOie6-krMEr5sFQ5RZrVex1hMNzwdNQPUSEMxHDLX7ozpX0DyNLbJ_V92Q1fKuIEcje1B-Z-7ptkhhs2R3E0vfdoTkJy2O6E5yI_6gvQji1IbdgR0VWXPdo-jsdo58Ts6J=w1300-h800-no?authuser=0" });
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 4, CategoryName = "Садовые" });//, ImageUrl = "https://lh3.googleusercontent.com/pw/AL9nZEXXh46G5MUHBuxh5g5QoHSjCsY3G-zmKj2wljY83l23ifCBZe3WmKsV5kIBTT1wC4be87z5K6cSZkN-Lcuhr6u1WNYJjO0GWsoko7X6Daf9-fgAB04lM13F6gEA7oLdV1JAiqB3OOPxRZVTRyAwiVCv=w1300-h800-no?authuser=0" });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Ландыш",
                Price = 15,
                Description = "Майский ландыш – единственный представитель рода Ландыши. Корневище ландыша ползучее, у верхушки несколько бледных мелких листьев, наполовину скрытых в земле.",
                //MainImageUrl = "https://lh3.googleusercontent.com/rQ1miACGTS2JC8xxfHkuH-HiYxqrkMBSr9cqxBFW6PBWiunYvrVqq74Gmb2IrbkVYfsSw44JMFjaMHvQqpdFoy81cGiR-DU6Io6I8UQaiyxlpDut6rZ-JwUay0CfDAL7D9fDT_KUCBaV1xYd4B-HrVRe7HJuXpMPAfgUhFPwTzZgWxuh78ZEEbNa8Ooy0IKhpmVMMaCHk7-uCyVQ_oWIU5MkMHbM18vWX1VP6i-FgjUfDFtIKlZxYSh6jxT_fBHiAjiEl9bgAFbTB9JKK6R73TOwUZRs7YnbUdjbpWCn1_9by0eWZIHLb3MdhIY_FJOyut-3Fm-gQBETrQwAUt3JZ95t43fdjAohg9QhjLjpKjBKxVcJToFa6fZ5BHGmKiMYzl05kT0O0fWakjKnUonFmL9Wb3_zTofbhJmRf9haziBmkuv3c-_Js1R1p0watii3uOMKJClZ-pF3bYowNWtDSf13JKi_PWZaRVBCmb1za-NxzYy-N0Lc2yI07NvPqT-uh9nd85FYSJEhcM_vOw-P2axqGz1ZlBcCI6Wv3q3NJvLCVWZmEiSIlpaKVBENRloJB9620FVrd59coBTTtqm8zjAjXCsqMYnM7RxG0y2W28ZftqtrDXuiBpIsHQkM1QPNR1KEJ_QdTAQNo9JcG5otADQ1amOnc_9yw0KyqF7s14a2ElQQemU7GuNJvQxa-rG8mpxTwjtTPHyDJwmcM7rMJoi9KM3jxHtZAmYF5L6i2gSSjFL6Zc14bPBU2NbGVLV4R9uZp-q5ZwNBktsNJuFhI0uzH1_s8L9ld1Wzdry-E6FRfMy_3lHIpA1j6nNmXC9Cc7J-Uso2lWe_6zfFhI0AoqE5KQbD8hTxDKiGpZoNuuBZuL3Cb0hAVL3qG-WpR7ZCLftaCTjd-Yn7_t6RnvRRYJI6OoXIGTTN4CSM0HR8I27tDui3=w1024-h768-no?authuser=0",
                CategoryId = 1,
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 1,
            //    ProductId = 1,
            //    ImageUrl = "https://lh3.googleusercontent.com/Tzil_488tuOPmLm6KyJJkPaMkehCU8bBMOYn8vUSUviq21s4jOsIxWMNC8yq7gFWb5hVMTtpemRLRV3rbvy8M4vovQzHAnR_ZsREsSZqhdEvq0WIjH86DyMOY6LR3RF8D1bTELTiz5xUzYWeOIPlJ6s9G-xN1KwlcqExUNjuwFSr2UfFTf2PI3g0NIMuy4vetQlmTqdZGuDSaJ8eSR6lheJ9tEVK-M3797OtTuJdmWLkLFQS-8KrGksyDOIsc3hWSsNK9vcT3uPrEknwFElWIubKcSHNRGGs4a63qx8bnr-8xfhoN0cl4jS9QtHz7dj1UueG5-aWel0LEXtKreNxL87v_QK0OUFLr3Vb_jvH_r3e8Y0VqISNmuxpiTMW7tKAYRvYu_ftgpmwzjArwXmtRLSKAdI4kHLUOgw4SngBxkHDXHPgtj3o4L_HMyCSwGvAeZkNFvKR18Gz9IGVNM4rZ6djheH0w3QqMzO5rLxxZHcqBHfRw-mojWWC_FWbCJPCcyad210M_dUa43ZX6L4CEnXvpH5UvOBEJkkdLzZUyOFkYKaAOpNP4v04c-lg9E76qw5Oy1wCSf1UPY3Cc2Nwn8KO6VHLToh0POo8eS8Ti2Rcn-51zvg_N2BCnqEQXPuvlEYvm_7tuYN0Q2c43pwiZPNoEjE7VvdLkaCo80vYGkj0dJHaSlKQDLJavHr4gglfWae_lh_FqF8_feG9Oip47zPO9odQi0mS2i_ZZibbpHKCvuJEi_ZEhLYaktZPiFbCFg2hm8bLAJyCXAfwK3DpXCCGzti3uz4w2AuH7xivZ-sbwUQEE9ggmixv9WJ1raIADccPq1NawY38JM-npA68I-nWhRVJY9yPMPQF-qaakzu3HIQZo3Gi10xDIzW--CH79ZOE6HjRzxVBHubOfDoXg9eOo82yJak93raCEScC8thX3K8O=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 2,
            //    ProductId = 1,
            //    ImageUrl = "https://lh3.googleusercontent.com/Q8dDyDONC_dRkSLOLfBy6QbHNiCVZns_fAm4FkAI9Zphn5ZDDZZxCmMMGuV4Pg-xUpkgapuVjRNjXSTmg8-bP7tCpj2_yakYOoBE5wzqGaY0wcgh_G33nFMqz04dUyu75TmyTqThldSHrLzC_go0TGHNGqy5Et-czK9X5R03gk4vfYAQqdOTYj0nvL_YhSZ6WJWszsO0nIaHaWDngMos5PG4FbneENdwqXCmkx1PuGarP9eopJNv16vuqiFmzdgDmXubil3E3NfIFYPqq1iQDhQCi46C078w1MO4incq0oaprfsfHxwC_TDo2ODJ7Gvz5sZ5CDwiJbOO4hMQ1hSwXFgBb0L1xXjC-W6sWVvr3eUUV2mrUJzf7RgksKjcgPQb8hz8QAN-D6uGUK4Ynp-vnSmOiKKibDFZThJ9mZzfU9FXKtTNtX90DQkrRwX8DfZVCyoLSndQ6OyHiv_A1A4ZsLvnXpNkecED7EuESRcnCPyJCE48dulhtzqNThh6E5Ycx9Nv_WCNE8__yHco2CV7XjB81EoPUUCW2xwWHW_qn1J-Ono9Yhh6wUvQg18MgNyCpwp917Vf2yizx1cqtx1D_46veE7a8rup3rXt9iCt7u0wH8NkNJghzv6_ESihZKlZI31g9fkW6TYQe_mDCTNUfvZMU8aXQoAjM6ivne-DDUpUWAMEOlNqaqV-0Il7KzusIfSpPZoaOCx1lkM6pktLs3ZO8WKmV4B6Wj1Kwfy8ww0Q_w3KORyKHKvWSaPR8_kv5_k0WUkm1IWa8GuHOXxhyFO_ETTRJg6NzDC1DYYRpsqJBKlOSjuRfiLSQVrocERjcgc-wZYsj-k4Hp6L9V87y-g1TWjVvnY6kAQEfImvw98MEYdNuHuMsph8JoQ5Krb9EPPQbYfvGuWofFAFOlb2tGFFHlcMP81HHOiq2xmvK6dkyDir=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 3,
            //    ProductId = 1,
            //    ImageUrl = "https://lh3.googleusercontent.com/VHVic-p23Bkdq4lPXwtS_T_4MDzDqxMNRFkhP98Xy3yQS2mAolGEXc0Kg-FkOdZIdK25lnT1Yf68rfkbPa_1cRDy-F0JQ1_ch4-xS8dxmZ_a1-acq4zJVRDS01JNlcO4w6sOAHCDoN-vVr9yUyR9sFtrj9D81sN5CxDwRIHrItYOHCb99qlDl_w8b8YfylClai09lWAgJ6zy2NgsRmOkGjhbpLWb5TjqHReQURzQfUsNgAs3SHzoeXMUHy8noOI9lzoKCKTkanns1AtGPOI4faTq-bop9MxuilR4JLSZqRkbqVSx_F5VTU7Ju_ijF5TA_icOM1_W9OjeBmDcyIdW4n0--8ip0YNZ0ORkhBO6LL0qbOwGVKvXNf_P3ln4B9Xr7ruOk5fjFmk8Z4N2lH1abXepMX7Ia6skeVuitFhTkDjZlV_rhcxhN4KUjJlOqlJeq33hPJCB2jHCBN7vEOsflP8iUm9B6y08X1mlplQXNaWSNPJpAb78UVLplyv_KVwhNjaGyxhYIyfYhmVY48OEeizsEvbGQnqr4osjmqKYemdPM-JmSNUvHQ9s6HxWQF5veX6A0xwk58olrTMFO9tZ4383sdrrSQdCIB767C3FTMAmsQJAbXSGSgx-vadoUNfSuGHx7P1cx5OFAOlQUqahb3v8nBRe1SBNi8VqSbu70cP0IaRC266hhKVsCYYdyKWB_n-wxbEaSeDYi6atSfmNa0tyGP710KpUveBwcpq0yLrknCTeq1mRJ1xCQ-ApV3Tuqro16OF1BGrq0vOvdj2QOtIk1tX_HzIB4RZuUjC24fSYRFdoASAkPsxtve7ceEYhHLdB12tAtHFyFQ2aSIYnYHXfbShLRFoXUVvQYwYoMInwQpI_-rkWIjbDZdIlnVa0w_NWHOvtcoEF7Pjrf0P4XCzAuHeDf4erxOR6jh380V11tD1u=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Жасмин",
                Price = (decimal)13.99,
                Description = "Жасмин — это род из 200 или более листопадных кустарников, вьющихся или вьющихся растений, которые выращивают в основном из-за их белых, розовых или желтых сильно ароматных цветов.",
                //MainImageUrl = "https://lh3.googleusercontent.com/SUsmUADAPqipy5OU1sssNUMz1rw9nXdy4DyH_SWtzMAz2dgwPmGpPTpBrh8d5C7NsHc3PuicLiCECi-AN9SDhtn2jxOdvKCLQ-4av5n7hDToJQzIMGFKaQ7EXOSGQtfn_QQiweaZpnkyXGOo778hzJX097jl_Qf-Z3Vzrnr9LuNUWqQzSrPPswmKir4es3ZgrbqYH-VTGcS9soRojy-6fb65RcseSBLLoiD63wGcIF00VZWEvebiuV37lpP1tLxtRkQ7mc5YXVZZ0W_Y0vWpgsT0HGd-Pqss2-x58Br1ru0ZfPj0S312uVbD_O1iDP1eaHX2ShEVukAZb-0w3WLN2horsYKodKhO5Te8YF7_F3AzioLCuVbCrAZQar9M1QVyKgG8hBda2XmWKKXU1-fZfh6I0NDIZz2zroKnoZ_QYw-crjnIe0tIsPO6E7MFLA-7DFXvdHcHxBy3GpkwD1BDyRcf6C9cWjwUWrDa6hdJ0BJZTyctQbTpwVKk2loa3LFSLAKfudA8zb2-RB9foqosyu8kWk__5MLfHGeCH1EhY9cfeJZQm3DelRqthV1BeEjm1AtcA6lHb4ulzyegt60ix8gtQ6JHZ6AxGpZaHyP6Bxtl45vlsYY2xddE31FyVD-vwzKGZSv8r7E8keP4E9eVMelkR8EdTvIJZeP79-WqJoKcekq2y_1BUu98siHigGC1QdYkLwobXysxwUw2fVuhpEvBtgsvJYlOsIVZXJHrIFmabJD1wkShd-QdfkdgMxXtzz3NDxdMuPC_uFqelBCthqczND4EBYImgM4YpIVHIbQZJ26ChRT_-CPq8w9r1zInTcL77DaTv--rk-NIbN4eFdySdybSl-lbN6BgiyB-rsnHtXwkxZx-BOrO3DfH3riIMqnhsVZYF_VRBZr08V0U4hQZ-lQPz5o-7RCpvLtw9CAUppNN=w477-h358-no?authuser=0",
                CategoryId = 2
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 4,
            //    ProductId = 2,
            //    ImageUrl = "https://lh3.googleusercontent.com/QyqD-Y-q-c3bXXIpzlBhrGlKbUx-DV8eg7nqraCGlFelAOohhAwK-xEaCNgNO5LDM6Bmh-v5ZAMEqZIAdAJmcbo016ahQqIKDwU7IXI9OJkBN9x7wGYmN7htiCuXc7m-dYRwrbJiTuT-a3uIcIp2S933tHC6j9V3kK52Z8c8Wy7k-uJyx9OXkdSeLDT4vX4gC2cLFqfZL_h2NBwGpATkRHK3xcJg5ok4oqog05MlZy9Xa4PABPBmzRQzGRP8anlvfTOkLwNv-AJOJeR-kcv5QYlOEUJY4KoJMFZrZRf67XYrqMSRhlhltBYBYccCNieklVqnIv_aAlz-RqNYClUXj8yf1DatgT03VoECSxISMb15myCQhfCRb5a7Aswdy9KX3L3EaPEkdA6U_DYdG43GcLnhQ0EBp4TpBzJ7Hq-odKo53dHkLcA0QBh-nmo33SxdS655cOe7V9sUBNWWLqStxbuv4sjXw38y8GQD_XUnWraK0Yzel6CQl2FQupnSFjCFroNTLi10JJn8In1vH1CZF9tBWYbHLPS4wf03v-7vZiXuIh3iKySqAV_zrfYcZy6yNzmzP8A7XFkk5L2BvL4bUKlvEXs7S_u2gcrlKQvwfc-qzh5jEutflSOqMnab5ruP1k4e9KQAFbcogUDCobGwmOexMR1iVwb_1fvHXWtBc9hdUdubhCUl9Z0Q0MC-WQRkAUCk7JE66inCcBRzJRJsMeRs5OLFGUznChN_pegiafOq6Py0rNpON8YKiHKi95oSrdb4QotuelxL7vVZ8qPcmGTlkoIYtPPS8m5rPwoCGpKfnvGTJ_wd_uZMTpRn7nBjO4T6XtJt_Aq91mjMypMpJ-Z0lgHlZnDmh0aFmPa0eC_tNCMnXlwj66t0OQPGPyu8aV___KXu_qyfWuj5_ObGtQF_EHvM-XDDjVh1AJNPMZGUACbR=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 5,
            //    ProductId = 2,
            //    ImageUrl = "https://lh3.googleusercontent.com/977BDrWKMM8BbZcc04OiOQnVrqd1uBGF0mtang_iFus3xcE6Twm_Opu2Zl2lCibPoDkhh4EsvfNYr-Cn9eKrN_etRJW7wm-uCyr4Ft1FrvBmQeVpxCMcNDjHJ_V8kD3rxtFZRQVPhDPmN_Uh89887Z1h4mD12zKHMl1HOujyzBya33UKVvwk4oUmsHeWNdotgepgjiLvZGFJkaO1rmN8xkXRfxE0LF5lvzseIPh02ytSdcX1cFKzOqvIMUX1U6q-msQcWM9P1aVMNswwrPDjvfsHFZclDceOS1tbhISEh5hocpH5VpVJ9LHG2WzSUWyALproN49AwZH5BdQ5bk1Y3a1Pr-NHXfYovZnk1z72zJ6rgiQtlO4RImGryvQK8gAc6a9m6q3sj4hoz_z2QiBkcEsLCkX10lu8wMfl4wfv4zJmRXyR4pt1P12SYIP8fcpaxjilpO8xr_tG_temQkePIMrReSL6O7qS0sejbgTBkgzo097ml2fQsZqdzsxBwoWKWU6-8PqodwVKKENKyvZIjuP6cQMYk-qiQbIx6-at_CqVb-Beem-Gn8SvEzv3SuELKvScGywF-b_pk4vXGXjn42kp-BkrvvjEZGrieU2295Iv7fuiaFVziRMTjVgPP3e1-K66V-yDFMxvSaAg1pVbShoBviS0c29iiaRQ7ef65zZyreD1CI4FLkBjc1bWNgPjRQMcaC6s5_7OTg7Wt5qyFZK9CBhacs7r7wKmCGB9x1r29fbOXVzeSYD1ms_KKZC9w9nV6bnURsaQ74YPpm22qMwev71jX8n-934Dw8Fhc17FBWZA-r0zBYR-vJgmDdY4xnQeW794otkJc-FROt4lCJpwvFw1YewVKcEmWjxBo6hIR6YZPpCgfhneN-By9leuNTLv87Y0D8XqN2YTe-4HPgjw6P35J2gIdo10ikj18HZ02kqJ=w1200-h900-no?authuser=0",
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 6,
            //    ProductId = 2,
            //    ImageUrl = "https://lh3.googleusercontent.com/0DsJ_0TP32P_vk2ZgsejY_8rH68lXkXkP273plL1r7gTc0YN3hRIWYS0qj3fNgfyisaUVwUCtQ_0bIQcUVkwIc_gcmueoaCHDzRBpDP9yHgSC0h7QJShL-2l9qgAvkXhs7eZvEWIZpTjdiaquG9sUn4TOG7tp3LDn5DhTPmZNQCzWxug_lxZZqIKFmBBFuvo6HjqHkUz4xel2-aX2BKT2LKyGFOpp0EenKg6tR8D3YnEedwqGA3gwkAFzsAETlhuAC6zip8JKxkGb4D-IPl7_KHzbEyFqoKf3gPjGiJgNr4lJGSAmPvPx4uLejg2D0TWnQqRptXRgX_xx_5DdLz78ab50_fA277FFWwNtdZcDOtoOa2nefv5iubHgmp8MQ3Ebik8dpxMZ8lhObc9PJlp20jJfPjx7nPkWNi5iQDbTtkD4pumii42LczERzwO6yGid7BsnvLIBdzvxhQcI_4AF2ba6z2WPp-1tq7fBQC1ouESYxxI0R-0Cc4rSai7oZvK_WBcvPzRRAz2hl_c6ULRFdcZWTBehkljeYhzIcP6p_cdpUex7pJk0NqSrXBXNkZb7GB34CoWfUdATOYshUOzlLOxdoO_fsySoE06uQRMwXjLOZlCaTZVHR3ecBBmd65tVopZ__uhhTnFIGH03-AdJR1rVe-wu-3JjNX0hM7m5HnU0XCBUC10hEut6r18nslAV1zZG77ER7ppNseO2EtlKAzv7aa02m3TU9WDJThdeSccDndC_FItytKN-TnVjKcITBp-nKi1Dz9C2XntvrozvyXCVxQIRRFb129o7U0bRo0Gjae46X0YbqmhMYxeOr0hTmCcmMvbZYB-dPBYkbuWkZ4iSH6-92cQ0ngGpBZWki69P_HRYtCidZchbEGzBLjGGb1McLzT2vkpEXtQoHQg_F8waNjqDn-EXXgjrmHhVxXyjC4H=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Бадан толстолистный",
                Price = (decimal)10.99,
                Description = "Растение травянистое многолетнее высотой 10-50 см, с длинночерешковыми, широкоовальными, крупными зимующими листьями темно-зеленого цвета, собранными в розетку при корне. Когда лето заканчивается, у Бадана краснеют листья. У него длинное, толстое, ветвистое и ползучее корневище.",
                //MainImageUrl = "https://lh3.googleusercontent.com/pmkIti9oZzUAmxJmKzZ-iSMp1ik-UkepvB5S2aSFNtj5GsjFKrAxxCN2eDISyDvOt-mMY36fKnmYjNzAiuRoExwVx6c3AfDVqS7Q4ZPR8VtMmtqHAsfoe0l9F3L5xaX_rCGb8Sy9tZk6U3oiG0-c_ccm_kxRyAyyYyneE6GC1zq36SmvmEwhQd13ArODB_L5he8xbioNWvrjm-gzQgBtzMdPDoRAhb3CVbxAwQhY2dpVMbBQQoFLZidxyb2xfXDQyWGJ_zY0qv1zuUugFAWJas5pOEwoJfKIokwRLyupNnSCDaH6_qLGRv6kWZ4hcv7tD_Au6XaHe9Fl2OhsDI-EAB3FS9nhLyNIptkK_L3XBjNCDLHDruUPg4bDoeox2_VdpwnbKQ8PKQYJ356578sM3Rvuna3oKNVImvtCgG7K7Wcc9rs0GcDh3hmSKrhwxS3VxDX6XPt_q7tTUCuxrYhpm_UyRruWXdO6VCK-VbFbAIQhZq2fV4bztjOHLY_LfVTPqrXHqY4Vk6bki6dgvw_O96Tf_SG769Btuz4bKI6DfYlOkznmehzMoXL2lPM6_vGFhsm88xj8UdI40O4ugLx5w284HJjpSzUKsWwJlBBSkNnIkgN1-Pa8VzuG_4fegNInken2WBIUM-0j6uv7PEnYwrtZMf8ZfmTaYOXOkiMHzBbQBm3GAIxjid0UhzeywW1FJ_Dsor1zPMebVoHPqlKtlSMMCsBwfNUpPVz0GSOd304pk6cJaJqlDK9Ja16ExNfIoxl0skYeWUC7CD6LL3WKqQWO52yPinam-6Lq5g6cSAPOOC2yB88eoWGR1Z5btkdxXYYsyWgumuPVhXkFeSIOMKB8lQiSg_E_dVOlc_v00ZOFU9NOdItb8VzTGCn5xWBPpz5gZUn_PJhUhivjMPrfLg9qWXFmQTkac71WxanAEcZt-WOq=w1024-h768-no?authuser=0",
                CategoryId = 3
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 7,
            //    ProductId = 3,
            //    ImageUrl = "https://lh3.googleusercontent.com/AEeT3qA-WyeeaN51YV3bL9LmUTElCjFasPLaIQqNt36Df7I17FolM8QUEmKLANrZP83g2R0SYDpmV1p5fSw7E9o8q55BV8dADVy8M9kwGUiXUA5_qWg4nTi3_UuHqaXmoHOsp57FCAolyvrpGY_TkNmknc_ojkIG8tDKp-kTR8gTmO8z8VHu7vwOY0a7CUYkDivCp1RCQfjQ4yvIQt7twHOXvosYju5MfgWl7zxQ8h_5r9MgmIID8XlbIo1YY4ovQmEwCcb_tlaM_SAMGe5iMKAkXjl8Dc0gGmiSVoEJGEPMZ8YnsY4P9QQBHEBkmQcmMg6apsfRQZ5aUK_Jg4FD94y8cIxgEsPOIIryjh-cLLhbkR11xC-THoMzyJmKPTuXCU2tbCL-HO6z1UrTqARonYA487rJEbdJVsWp6162z9h6E54X__zzBXAp-HoI-jMcVIcIl_HsdTIuNiAw_OCuPpP2ujWxzB-i-KtsrXOpVmp0XFHnUr1C9aCPVGi0P006shmM1n1SxMqrgkuwYLeCo__VIGqVkk68CHnryFroPRY95YdSIktnzinFodu9xp3aw5Ihay3NIMgmjUdJ_GCA6hRSb-HNDXpunXLvLEHFbUBvWtXAY_ivHKnTYZ7Sj7iljieKrZSdiHL71NqkeaG6kJWjdKggnl65WXwIPdwWrYWXbyXyazAUKm0_8S1jsGhHZGnVYcTyHMs9B4t2h1zIDTmRxkzEecsOsOFWaDIAor97DR1a0s3CiP_PijfLRoGV6gTWIx29AVBPOvPIxM7GBXaPYr08Yw4VHE-fAXyzpzhmOquKgsOHtCso6pzOtvDVMVg59npEbSj19X0TkzQ02NQPOTafJ7wdC1yGSAEm8euJZLJng9lzdHg8aNKmPMEGk2Ka3HZaSy8GwM7uD3Xm_DWej5C3IRJ_BGH92CEKEIxSIqf3=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 8,
            //    ProductId = 3,
            //    ImageUrl = "https://lh3.googleusercontent.com/d7UK9PYX1aecxBn77HGcKaaBPGdQKWd_Ux7pKrH8-prY3ecmeK8GJYOZ3zGGru2GtFxruyXubDjyuqD8smOO21k9JobhmocXZe1bOL4kog8n7T5AdfbUwtDTmj14Eq_Yql6CjRlPIg3MW_vblmFgxNiR1a7x8I7K0FpXhGUq1T5PaKTwVK4Lhc2VVBvmqabI0j--NOXcdlyXV9931P9k_uO8Ajv9PLuQOkpe-NMc9uyhNO61b7Erb7yI2Eusu_kDirabm5WCHymkHGXpLm5cAuncolkU5n-nLJqVe-sIcs31rtc1tfcIGyEDqLbr4TmqyRptjKoqkqh3hFIf-7xg8gZZza23jeGe2MZ-8tDvbEu00L92AShYHlcOMT2m1t7CVF92MXftfjrL1Jyrm2z9i2HyAmC_7oazoZhMnDsxwZ8GJ91UviiHMBS9LJ4iqvgTww8kJChocaUnGRodmofTepFAqlZbMc0rVOy5qxrU0KInTUNWJ7kK7_jgiKQzVfoBXpXRtUonY2CCNeNPBUJylCUyeYLGn-76SexJwvu4iulf0ayNz3aic2moITzo6j-gEwNA8VIW0a6UUfc05MJZ_JitqTLWDsLrbDlYcKkaLzgpR6YapuVnYfEX86jjvCq4AbC9YuSVhNMJlvTs9kG8srqWKbjQtlHso5hu4Ow6-5xGwt1GTebUDvBqS1dvWN6kw7Iz2aFPsaJpr9nhOTJPqO7vzXsbKQcj_PSwrAtZFHBjQTY6Ze3BcB9m8p161I3Z9X8WCI91T-jHoRkGvAldQs52N4UACMPKNLtQHEL-gv6vuM-PKFWZduskRBEAHJHxDoBtLy2ZgTAYYigGEbMOnMYjOBgmqg47Qwpiyv-Wpuz0R0_f1MbuEYjzWfzslmaYjSJsY9W1YulWJ3yH3JRDjG6GSW2NXNXUkIyhW7kTmC9opMY1=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 9,
            //    ProductId = 3,
            //    ImageUrl = "https://lh3.googleusercontent.com/qwKDemvGdXx94197qVotjsktlecOPBuHpFvUqBDXpB-SKB_aePVpJsv_vX-yYEmJqrr-c3AUkdrTBQxVhQjXINF2M8PsZa7dTtS8-jDQDHC85JsuXgs-5w9Ml-9cErNv95E7hU6j3UYuBPvhxmunKGLJrnaxbDQHBNc6Sr5hV1GLiSCtRQSDdryqWOugzUdNcqkMoKjn3XlA94j8D3F9ZdW4Nx_e_E2FIZ_0_rsZUIfhOR9mP1koxi-xCLkqRfIi6fUBLDQHr0LnglpJ6tJAaNbvwkqCl1v4-w-Qh0_piuA1UvQL8nN3O_MTYIaRUrkd1vd62jYreMXZlcLiFXlZrdM1KkQrNmbNnGH_ZaWWSDe85iNRVIaR0cz_2IA0KofiP2Y0EB5AaLHDn33rBo5uBmCiCErolYOhnmkhqeFBkHojT8XosWU01kxEFpjYqPsLQKZ9eSC_zme7obKmk5d_L96GftntV-LZhgG_WzZ1M7hMvDbMNT-BGK8smQKsizna_5Qi5VNO-nV10MpBlu9aJ5LceAr3WaC4_cd4QHJUIKRtAgTJHE9OawsC8kuI6evSMuNzoKrz9RdxAehHjTNFLUzxAb1ZjCoJXJh5YpxdYCAPLy0B_1r0Nv5ct0xJ8CDWlSlyvXlRjiSS_iQReOEl8utfNoyprz18O1N4D9p9FgvaIxhd7zOm-z4REoQVKJDHd29XcsRer2ZeUZiOr8nu7eII2GG8nyE0RHzKoVD-TNbekuen-JdRhjLjlsrk5foNLSuJOr31ZSkdmfu1xHxzjZ04W_jMrzfwzJgnDR9TxCDIGXHadeK8ZJChsHnYhkwxxh0NSvFC5M8uf6Icxpjs59UTGwE0GxFIpvMv3qo6PwSZnKWSw0kE-POa_ruikMxSIIgUJdL0E4q9WvCkGgjcFhf3X9QndFtmbTZ_6hSqS2M1dJ02=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductName = "Дельфиниум",
                Price = 15,
                Description = "Название растение получило из-за особой формы цветка, бутоны очень похожи на голову дельфина. По древней греческой легенде у одного юноши погибла возлюбленная, не в силах пережить боль утраты он сделал статую девушки и вдохнул в нее жизнь. Боги разгневались на такую дерзость и превратили юношу в дельфина. Возрожденная девушка однажды вышла на берег моря и увидела дельфина, он подплыл к ней и положил к ее ногам веточку Дельфиниума.",
                //MainImageUrl = "https://lh3.googleusercontent.com/SwKpqoi_RVf42dY5S5F8pIUZqY0fZwjIfDFeMAoL5V0b27h-OdXLiApjWT3gSyp5KenlOvWeCWPuSXo6HgirXeA3IScGY4UGjj6sL8gvVZuKrT2oGwNwBLDT78l8d08CYW3EbOjvWEA6YurvQhQj8ev1arrKpPyfkxM_FHayK6BLFmW-JPq-KHe45hGMBCkOwfovGApBr34X20uvTLLRGog9k-EctdCSyEB-Sdi37VKZco2vLXQi5FKfdciLZ5dCc1uTMIOyRTiXu9UGtSkg9R_XDvGwshpI_07yvqWDLhQ6wjsBkMgFEhtGbvPnkeRqnAmS9J2d1pZS_VrHEUQTIqysnk79dUfkYE6ZnFIiXd__HgKQYvDN7wbh01RN2YSU20SU1f9i3O2ZEo1TNc49OVE2yki8bbs62ODrUJkLNkNzyUWroMxktaJKyCffQ2HXSyh4fNyxVm57UA4wbVqnpdo3HOM4Ztef38HBCX6ml-TKFziGy48WANcxrU6xsyu2wcch-D0sSUvcJzBvBwufeRg1GSKYVAujW9GUmmIv0Lfe7g7SMPe-YMefctgYdr29DOlsbKxrF7P8f72qu0EUHsY5TpnzHsQj2qMOc_huGm-2OB1uPD6vduOmVTpFP594U9HBsR9LdskYEomX4n043pGEo22W8qCu4A1R6680VnDMI4yG-C-x4hkpJ6VNMhXlFoU1QT3s9XTkPfvM8GIPfMV98twFrIp-a7nAGOzZw3PwHL7qLTlvsZ_8159NgLShnZaeki-3Vc4g2_FcNtAw39Ter5FJ5BAlAQNQjzawgUnsgToZunu6NsIUHGWTlvY81vOG6lkp711l9Czcg3ENlpNg4HM80ZJtxnYsf02O4QO5-6cbae-WZdDfcBb0i9vmdNCJJJbLHUWV9o81ejsdV0OaopSfi2tOaqnEyGvCkX1U2gWw=w1024-h768-no?authuser=0",
                CategoryId = 4
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 10,
            //    ProductId = 4,
            //    ImageUrl = "https://lh3.googleusercontent.com/a6zJKgVkYJk_RPOWYbjjJ2M4QPJLY4A00xpulapJvkgRguPAoSnyAGBA2R68SREVCJ77W_1V69xYpq-iVTfajKQm9bfS5gbB9HYBz8mctHJTWhB-3fuBcSq1qZC1dya14yYhmdk547vmv7uPrVVgaGoSuTK-ta72x9PuxMcgjPZuZRb3Xi2Ur_atBBlAsMfMkG0JoVefnQbjc0TBcL5O7yY8NJsh0zLpdRDPR8TUWR4uzpbMOOPJBumur6BYzm4PuuWi18NlgEbYFLLak-4MFwZ4jYgaopQF1KOrMItv58IBquvtGCJx4cVVZWKzrEPk-z8wuOxh99-O8o7JyySSqxX2wMbwSpV0gwQLZqYLs2vodEtk6F9OOZUCqHm5Rx6JGMGA389VlsqlhZtGmGSRuhMMdxaOHuT666IarqYqPji4Bk9JUQez__a2AaTfsAhLuMnCMa0qus_6Cz_hla3LEYx1iClFowzqVq9_c9SWVHaDPRwQLmwtXxVEU_pAmmx6TtRsxyqxGIO2hQJbl2TWpGZmm2hV-5VAxHC3a7rP7F0bjApgbXF-g5a5DvJsAF849yA48C4D55-nicVTVJpjlCBAflpJ4qOqqOpfFwvVgr8TDMT6Q07SaPbkfQtyTbtre0F0E33YcRm4_Pw-eoJlO2EZENOQN7Ibk8O5MEoD-4Yf9bBfyPDENbVqopmm6nxLj51PstjO22MbF_jDpuTnLueNe4mltQ-SOsPs_Vq1OZpUffDuqz4KDD0yFc8SUCBxPxtn00QG1JT0S4nC_SSnIYVhWbibQrzBdqYfM5_XwSG_z6J_l7dFB9ftYItZNzQt70Vypx-7ddN4fPyXTQ-M0dprAiKGg02lkZP0nlqqE05wT69f7-yDJ06cpbjZ6k-LsdkpMwzJ1w3e5CqXpEl1d8sIqTwpLNGRJay6w17eWjXJRant=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 11,
            //    ProductId = 4,
            //    ImageUrl = "https://lh3.googleusercontent.com/ABN1-m72kKjw2gGUOyuNWF19NvZL0CQoTScCTaBpdcrhgsrdV6-ac2chwvdiqSb6pg-zplY9TgpGQCOmMfSG-h58MgmUVrcjswqxuIdQVpRXuLuNNWSIdYXHlpWzbRWxFin6c5wE9GBf03l77eBeE50d8SoG0q-CZLGuL40YRreEfhxr5WMdG6FFOzaq_S7sTMofPnT3zOy-53v9KtxVFZncy1Oruee2miTZLcj7qNgu6yl8jW7r0OU_22HO0zBWhxpRwGc5MrN8nujNm4QkkmhIXBlqdOSwxaaFh9Vp_ATH4KC7_ZYR4VSqz4wkdZCa086YkoWkGUwwCmdCbIFcWo1YNTOIMvIUl_1n5q9o9OQ4K1R738OZYT0xOrmOtsvvWvpQ2jJy_kkH1adVgH6ib70K32TB1wvr4Ftq8Go5f9cSqDvGXy-ZzuEsyV67b6e4ZCtfOvc_EZQerkOYYprfZVwps40Y70FZgG82MRyZFPw3--Nde_tNFjlERgjwN2akRj3wYqjA5c0UY6rHrohHyYvL5pbiU2A8pBixMMiz-lTFeNIeeFEhoSyV_tdWZpaIugeKLXfXafcaGkYSeCxRNkmp1d0bIRNhK7bGyxgbFTubbJGp87Gee4shwf3YowqjPsvZxvs91BV0MMPuqZpi4VdFEHKUOOmuNM70SESg3chfFHwZoumBOUwrCgmZobleMNUuQhs7o-JkUue8rNoJ306AjSUruGHmSd3UGs6qo19ZH_qpI4bn6ymWJdenN6xBbKi1lQKnlGrbx2R7_xi25Ehq470U-DYlbPSF8W3o52N9G3xDIeJFGAmBzBlqFmFo9v34_X9WkqUS_cQGznOBUbN21DD8ybIvabMwYAClKGuSFRIW4AWnE4LU6N6gdHYGpPFyRdc4adQYx4hfWKu40hP4W02jKMMOvL0orJxE2xRSiPBg=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 12,
            //    ProductId = 4,
            //    ImageUrl = "https://lh3.googleusercontent.com/oQ13cowBd11Iv7d10V25W-YMqOnaeZXB91P3vh18TvGnx0nmdbS6D6fF-0F90mBlqoNLcrOvqZB_Zv8gY27-7cIhSF6uMTbAglYzk8H2AZx1GSsiYScMGNGzBLar73akeJ6cFFXhyepTpGZDiaWhZ8SpyWGFj0-2sisN1uC5odt076tuWspI--j9iO_p68Y4BF66SR-UMkK-bSyYatftRWni3oy02kutNWFYKTcSsy_lWCQS6o5-X2brtIZbg62wFTry5JoqNQaFgaZRaSNnDRieXJV680gWhqWnDEqvTRJOd7BPIWszbQlRq42OJmc_8i8hwYW-juxNyB2zWut4nmTePE3PO4shxBbbApOa0jvubELG1uLcJQSZTROl1Q3x_ib2JVJcvuXpZNsq6_byvoUwBR2vNiIyhasKXa-xhfBKHf5aV57TkQYWT3ZHew8V4qHuQ5K71HtFwcv5skej_H71npd83n6NrwbcXtV9uDWwnGyle7HnOVfscNTmqM0YIqRlOdb1ilCIGcUyEk2hR4mQVlKX2ygxwxMwPuqAs-VUsgBzIMNuYehJC0ozryOmVVfKFTCC6s-4DrG5rNdB_c5I6QaMxEwI00oxy9k8I_5siO4pn4OfAKiEJnIs5PjA8TsqLwlSKxch64RjUIzGWQ0sZJAXrCHFreIWzo2hx1Ymwy9V1HQhcZgvAzYheddg2TkUeu5Q7M5dCd5olnFFvHM7ykD1QcDbjQHeGqUvPlUQvbYAJY_Rkiv6GQ7WX7g7uCv7o9GUK3kR8OI313Pb82SyGMvbY_Rc7q6_HeFnGjxIRUpY34RB_PwxTug6hpdX47xxYlUn47pVapRQEfEz0MFJ-dcnObxVABfjKbe9UlWBrV7IYp11L3kWk29pf8lHHHM9lsDgcQW2zRwA15-EQs_2ES-60uSr2SGRpGRYI7JseQFm=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                ProductName = "Гвоздика пышная",
                Price = 18,
                Description = "Гвоздика пышная встречается по всей европейской части России, кроме Юга и Крайнего Севера, растет в Средней Азии, в Западной и Восточной Сибири. Наиболее часто встречается по опушкам лесов, в лугах, в разреженных лесах, а также встречается в горах, где растет выше лесного пояса. Этот лесной цветок является многолетним корневищным травянистым растением.Высотой от 25 до 60 см.Обладает супротивными листьями и немногими цветоносными стеблями с цветами необычайной красоты.Пурпурные, розовые или белые цветы с глубоко рассеченными лепестками напоминают тончайшие кружева мастерицы.Цветет с начала июня до июля.",
                //MainImageUrl = "https://lh3.googleusercontent.com/xDBz2jf_9J7etcjmVTPiV4RXkkFZFSmBMYo0Q1r4GpU4oG0tDxuT7S29PYBzOoVtz4D2VUiic0HJK5pOsafCydTBlQNm8uU-CsBnhj3CdHOyQVpyOM5bJNkvfzlyYOd_Vvh6CZFqTRICh8vYl9NSh-IrMFcV7y7lRYOttLh4IwkIdSCpFLPs9HlJskkIShNK7kne737zkTNPZB2aLwMw1Xegu_PI6wy-wXZPmqRQgP3msk9t9MR-x_UrvTxW3J5RFaJG-pfEs94wNLxFnD2lN7LkeHLx-_rM4XUcnPE2wX_wqvq3AKYCDL4Olo2AR2Rp53JMeQRLu8RqOXKmbZqZvlZd31uDoaYb6ebHIbP7_7fCals0dfvktphw6USF6fYjRgQOo-G3G7cVS8eDiA9uG233sL8raZOrKMYgsdGdtdtCTDzwbwJOdc79ChjwrX4fM-Swavlv07r8XRWLkkYSQPUrc2DoaWt2IIwuAiFfagLJ4ebV8Us98iZd-jVfaH9SZdGjyyAOXBZwTx-c2or7265tu9PpPhqMhiuyLtAlZh7mjQ__ZfUx2W22uqmGi7XeN9qI03Vi5Tve8gJe-YdoaPc-ykdYxngBYn9p0R2MRSt7SIXtHvGYAqiguFVGUjXkF3pR_M5gXddrqCyi7q3aW6P4vB80cbVG4A7BsKXljVpZWpB3k00LgbaTzO0ALUOgQkZsnQGDp1XyQx9zo72aK9B4ZpAImA_V5m7uJDUnA5QzcnaryVCu7vqIXPPQkTgdoUocMdMcQu6kPJBRw3qiKr9P6cw0T_uQGUZafv9M_clQx3siFFyjhbMp_5UezcjswfZnhHZOuxp_TbdzT4NF5PGSE41q_Mxho0RlGUnparwHMPK0hIom2wOcVeNh8232drVOHXvKmPsMufctdFpj1KGDD35-LxgaSghELx1rXsLdKztk=w1024-h768-no?authuser=0",
                CategoryId = 3
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 13,
            //    ProductId = 5,
            //    ImageUrl = "https://lh3.googleusercontent.com/5KZPcFmlh2CrI4wa4TeS2F9yBDpI5mkgTZCfNrgKZoDro5JLgZAb_yn_tTQgHvpwqcGZ9dfU0ipVyWd-4TNTRZAVm2QjQLZu4Z5H731AA-Tpuib5VscbKVrVQBJb6sfIUmxWs8ivw3XjiQuFH_w_Lnj36hagqb7t4sQ9OEwOfZVZUJieNVjuc1TDOWt5z4JLNYKZKs-ZWpRk6fPcqCRuvb_LQm-sPDC4Ur0cZvRQ7kK9PSwxKwZehq4SY2VHGauLxDIwShCvYDYNMC9gzmlEHwJqsNjz03dagvsDuMOExDySTCUR8g4KpK4iidnsDfSzskoxH1vt5pkl8cZvGRevsxXv8b7EwVt90UE1YfWeunPIFNLNYwCpZtsCXJTCTtSsdpNOPXPHfbP3JVaSw_xduRyiznL6KrdASsEBKFzRZYN23yZL141A_axleXr572FTFxSNcH_P3x0DjmlNjSms91yhaezqD-tY-2wFbWfO-qPxGDmYryoZ8X4WF678Tmyhxc-do_9E7bjMyTmunhuwIGExlY6zjy8VewxYpMCWOPru0UEn4IXepRU1DhHQH6zMVzW27k6f772X9LbuM-E7VxU7WcGtiAC96uJ10y7PBWACWMuo8tf5T4c1rq3UBWYkfKPSC5owJleO5W7gWlF_qPvoLjJcCyTgVHBTzM7MWumaM5ier5CI28O0m_5aQuM-ysCzkkKLjeJzDJz9b5Xp1U3hPPSfcbu6kspAQG4B-dqXXNhMq6JxJFjXMn77-_mJ4qIsKB9t82gnSBeVm10YvBfgkVIwQ_YNobZpkLoWWg5MIC5cb56QoTQ0wYym5O-YPGHPzSfebG6guv4JvDh0sP_zr-vTp4bALU3dka4IUoAX-VDoog22aQ2GDMgeYRWkULE5rYNI8KyPaoPlDEOEh9X100Ql5-gGN2Jqc0JlOuQg9Wqc=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 14,
            //    ProductId = 5,
            //    ImageUrl = "https://lh3.googleusercontent.com/5urV3m2bCAuAkhbUHrC-qDzI20qfvJMMXFmq1G2YNfuJH4vfGgjuyEHnvJVYMtir_DaZL80frs7Dlp2R7dlUcNO6s8RfZ9XKXB9cimsH7TNQkT6NuvC2gq2B5mflA1_Xme7PecG9A3ZQZeKoiGABzeFxyEUvXilAt3myKVao8sRfboZZBgnUbYZlCzzIwkpplqsjrip8bdA9rFCrEz_y8mMXp8jtY58seoaAcmZUFPgsiYA1ozOUMIiXCclBloEWBZM7zno4P38wXKx7HictelkBXe7aT0ZM_HqX22RXzGuwGo7hEWRwaXGpm1nIb3PwYkY3FuhuFE5BNoQxs82Esi9QnltHC-JAIhiFkp-k9nJrN-ahGg7dSQ__VmJUNHIjT0_6yywtwf-fiJfVkt2lmgDdYVwhFdgFyHcOTC17s3qZrecyR5uQ1WxZU53Pzw86q1EA6MS3RC0QozUkJ_7ZlysnFsfqqsJI8ZMwpnVBIhlcu8xvpwesj2Q-sRfMmJ1SGTfDVzKkb0oa-mnOSu4xGrcDE6M0xAEoFmBBDSfPkmLdyYXK4V0iVs1LcrdPZl5kbXKkJdO0eNOqC09zK1ulBNJyWdUP8noBu2foBIf_QZxKdKeOGJ9Der73WFn2Acos4fwPLg9VOp6DyPCIuMWBb2BJQ9RWg1hKC39dQY-2baignzCa2e2DNbltFThxDKkR8FIh-_WvvGmnHK20KrWveTPLZ8MHo6pwwyjEEZronYcnzPxe80vBb9pXt9fMjNw-1ckDP3_KPGetVI2UopZEcKuPhtlBTToBdBYu_foSGy2POGtT_TWDr9prE2pqh6YpOEsk0NqArb7iqV4TV1dZ-T2VmUdbqzqD4Xam4_ZaaHNCl-1umHZpLmUC1sAcXWUEfmHHtSk6mflREnpVsOShaet6FU2Bt6cvCr5WaxMx97gtceJs=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 15,
            //    ProductId = 5,
            //    ImageUrl = "https://lh3.googleusercontent.com/b_upPbAbeuHrGAxhbragh8IP3v5inXE5QqMuTebAyFvZ3bNEwBqHbNxzbVei1YV-ABTTCQoVnjzKuK2mIqbQpg5dLt9dqe0f1lmrVSzIkJiwVUmnP4YHiQNCwhFSC_SJneTf71UlWgyXVs2gY5va_YBkQ8OsuWLJL1U_XbwcVlcpJq46sIo0EkEzH2ClvCR6pl5R5E6neITNxvZQsXYGs9hU5ya5K8cZj2Q-_31kpNT4YBXOb5jMb97XZ0v3KQN61rGe8fa1otU_5M1mE6yDzS0wKuxse6CR_npbV_YeBy71M9CP9AZrbU96ahaswtkegIKKgUmTZLvDYEeXBFnNUDapZ3RM7AX9Cu0UBpwJD8KTQXVJdfDQ7t_sou_ZBMjKHCm5uad-74o9dsrNY3j0vswqW3UhtAF4_IS5LEJvgVSF7WzoxzeYAG7JuBMuc6gJ6SHPl2W3GXE5a1HFrzOJiRuXUK7D7EZXEYLnuxRgwuj6qBRF9nIR-iU7nn8IoTU8z1ZrHtEW9kAev9XSYS7BcqmoFW49nyS9I_3TH6rVwCYQMCA6jNiJXGRfGErwKQErYpfHPhlDK8Kq3c1S9VTXxJKYZokndmaGxnMtPTABJJLvLwvJuZzLGucjnfAddU3BlML8LarTSwsNxEHiyPEz50d16V91HNwNWkRGijJA6qMvRJW7Z8u_IB5iMTtL0oNmVRMk-X5Rmti4ccllo7EL2gaXcIIGEI6mluHs7bv_fLhmwE-RJj7T5k8LBRiX7oGB9Y52ZQsFbfnTu8F5pYWnuGyMMt3FxiY0Xb7XxNVpJyLsj0a84rEnuUdYqKiNAN_ToQDQzbw9GMAQBorKbYDh9G6jb3Ff7EO-Jd5kAhD2O3NlXFa8KFDnLLjVw3oclR4e7sQdd2uslOKQY0NjHqunPVR5l6rHff6zu_Iit5849qqsMJf_=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                ProductName = "Аквилегия (Водосбор)",
                Price = 25,
                Description = "Свое народное название – Водосбор, Аквилегия получила из-за особого строения цветка, каждый из которых имеет несколько «карманчиков», которые во время дождя наполняются водой, то есть «собирают воду». У декоративных видов данная функция отсутствует, но у Водосбора настоящего (см. фото) есть такие карманчики. Аквилегия или Водосбор являются травянистыми многолетними растениями.Его видов насчитывается около 70 видов.В дикой природе растение произрастает в лесах и лугах, Водосбор широко распространен в горных областях Северного полушария.",
                //MainImageUrl = "https://lh3.googleusercontent.com/2CJATjuUJuy06wfHW95UVbpscWi1wpDC3CcmaSp40l0DL-LbkT66uAh-ucjAkC4v9ncEzl4meEOVEZJNWXlSTEu6JBx7o2KzOp_hPOHYtxmKIEwgU3FXsCP4QJyZSuOXuyNWl4tpcgHwV1idxbqsjKavh4RB_Ed8E6tbrvlMclOMj7vlkg2L-FtbS392W6ZToms4cRTQGBkp6uP0gxJGshvmAqGNsJK5_9QcaNO3selA02kHgG7WA_Go0mMMOiVWdKa340-NHCPrrpBtPJwqSdtJM3gJtUmdyUAc3vFy2SYuZcs-bExokGizAPUyMhmHzSoeUVAFW6-tUMIU5qP3aJH8CbaJcEhutdXTgH1SCpohufLpyBNvMfYyYHunkQERDVciqJSp-lHVNogpxwDAXeaEX-uuKecGKDNUtt8zvCPolSbvlWxShKoxYEZpEXK1iddtXpDyjp9dhdBEWDDh7xnTs7CmaMLnIl-FE2qEZ7nZAgFCyoA2ofINIuQPCFbecgnm9B6LYQI1sSk5avk0eRx-p0XI7fs01srZ2k0vBFRkNHljzSE9T6i7GnsY5S6IyqXanQ5QjZuOia8Hn_yAu09v3EgKwn1_yRj5XgGHOJ065Y5t1vpNxO_dPk4EYvPNLfWztbH-mXviTjJpG49PVQwiKpx0okSlrw--yQK-MABaOqsG-lU36cIuVNzBoABzyUKGecnfR4AC70BwagW-me_ckq8YEoPT4SyC6iqOsKZiyXKmA0M0NLKz9y7IYy7_rp2xVPVBeCuCIEGefynlAnJ_UTahhiwRprLSlwGoI8GdCgLz5iSo3EB0dbfgpxZqtymIkkuSEUruEfVPcepd7AM4WEBR9ICZM7a4lLQwtT7bedgwPUCBf-o0i8ejL2BtUcIfpjwHQ1Jwdji3UAMD8122EuDA2hLdL8tGgz0cqoX2yib_=w1024-h768-no?authuser=0",
                CategoryId = 3
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 16,
            //    ProductId = 6,
            //    ImageUrl = "https://lh3.googleusercontent.com/OfFSlbCpAhzp-XoYP7Jb5Uvi3nSNJr9cLPqFCnQX_sFJp3L8I3vQPpbcCEP_0QociAZl37CwzffxgITRWP3Jm-WIAGuhGeK_5qZ51yKlUSZyhNXjYgt_l-BE0yat7JNSDYRol0tWUYj-ut0rMH0wNgrS0E4ii-MLyWHwJRsOAOreYE5oCKlGhQOowkfzJi364t3XZ1DXqnMbD0QRrZ4BbWOuZvjTImVt9Y90cssWY8IqTCcTP5WViz6QIgoxYo3Evwn10hmn6GFb9Bvtj8Fu_fuzx2Au4EAFRyDiJmK-dJor3fMw5AwtZeDgRadzvFj8z24VKliJY1U9M-HEHsvXXe-W9Ek3XKTq87xuA2-ci7IwIEeynszi1YhVV5S32P4ekpOQ7EnD3VYD9XWjSkwurvEd1u1N4aPPIsSVWJBv-xRmc1W66Pywmwy7_9BBm4fixZV2dO8XbDRNq87ijG2FF3MPTh6xDLJksDRTpNXxqEJrijhsDT-wSv0wltPH0qv4APC0qrfn_NjQtnoNgcHWitcDU5Aak0R2FCrBtRk40Q08_E5zzOQm4jyymhdsavFAeDh1M-uF8Z80D9TAgGnd_bczpIrP8KwtHcVTXJ7kieXxWvVd2fGgA29ZggRnzqF2y9H0aiKbLbGlI7TkkFGS0huIRgYRLty9ALFJp_UupW4pV10Hyms3e7Ik4lVgTC9xGVmOCAdCFiqd0xwCnFX70awh9uUEZvlE0OdIkA-FYgJBoslq7RAyPasvzniurN-U_ozIgYOfpR_OvWIRxD6wIw3_wcqtwIDDzEKnBUTXyGHllLiaFLMnbYSKsfc8ef-kVIjRCNSpfWuRSSj_mit5c5Oshy0CjdmgOg4PTsPOFTznUbdIqAkUy08BIVO5hia15X5kt1Oq-myyXXQaxnb8f5N91k2mc8Ri8yt-vYZVEVufRTi4=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 17,
            //    ProductId = 6,
            //    ImageUrl = "https://lh3.googleusercontent.com/QJW5UyHLSFAxb0CNT_H0K7Jo2_-g3yY2LzF36-1q-TGIjakg_zp4mbO8LjgJNxufEDy5ML7IdWQcp40tYo9wzlMxYVv_s5MvcAkIBykFq3Hn0m9GwrHhZ2mYcZNNerG1Hr3z4l5aDZElO5hUg6jlzYWr6yb7FmaCJyhUtjPzsuUXhB8JhqperR0cMd2cASD15Qp2_398hC_yRNwJ2SVPGhrzYHhK1NhSTKhKflUi7p-4KnfyGyX_yoJGM1-auALlY5qh36qdrIdv1312h44sR6IuIMcWq0FD5dvnufAIRGasYizXpLTc2xIIMtOsPfGMBcM-Tf_lO500fkT3SG3DlJu6xqkjpPBhjMRGYaHQNq_ynyVcO88zqUdeuDGfOSkxQch4cmdqeIFXUTLIn2g0CTdvWtaNU7RAxusF27yEot5G2VNqA2XlweYI2DSxGExagE5mAAo65vIhfrUTJTE9dQWPmldkVGvz7BlU7N4i-CoAN8VqOJcQIMPRHyr_-iS_P8a7NkTGa48aj5njJQb7rPsXBWvXljiA4fNkxL-KJNrJ0d7LNgktJ3ztsTg9IuM4hCcEOaWhzoziOinEk_HKO0c5JjOj5F8AHIRt59jGbbqA39gN-Znhns8Wx0pEgWURTZtg8LGyl91EipaScwHWNJORk28gDA7wFmFyR7LPxD-yX3l_ubGMmkSfaGf73i5DRmziJQrFmEwH0l8M7GBGkf-277WQPpl41JeE87XCZi07BnIt35pxppaMCL_HaT56v1EvvlF_OWnQmpXins5stGMwL71NbuA5aS6GOCOrC3JwWfLJqfLYG0KqHZ1GimYnblKOpxavoe9qXmnHWnQmLkmQkLbd6nym_HhcEuMbyyGGiWcrfGD23UrnJwBjU0NRVz9O39UlrrDlIzdCIcvrRJ6UQiLwxQIj_slYCZ7l2xP_rN97=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 18,
            //    ProductId = 6,
            //    ImageUrl = "https://lh3.googleusercontent.com/kceORew5q_jQyikVfsXkWVcTM3WvfK4KUyG3ZDkRBKsMlswXvqTLHtNTZRcLRPifDJYO2cIUoTZVM8RrxC7Kf4isZ5BxF4-0avjAkmGPfc7qROUaYXNjcBovy_OVW3ojGs74UW4sItQk7BsTsApy35lsWu1bS3B5WdC-VPj10VSNPSHReZQRSdGr_9psrv9zijMVuEBdOzWTxCZV6HAkLhfb8nRKwbknf4jFOt5L6vRSSeXR_hIieV-HJhrDpzW9g-6qvxZgdGXmlY1TDoIdqN0ovOWFNkluX4Ws6OtyCwYrYyF6Mvf6igf2RULhETV3_qwChDQ2XuTmCa0G68AYuMKXka9k6ER7xoI8YGi_zkOWH4ud-ul6gn8YQ7xN73A1WyfhgtFuDWKkVbcNnP6D-j1sIkd92uniqE3SOG4m4FynoDsp0XZBGa3liXV0YjdAGTFjbOP6VLgGzVmmPchJiKsUFhp9q9hMszCTk0vS16tCx4Hq4fjvBz-89coHdIWq1jaXbaDFqScukpczNbRhqduvFBBKnN3DoeXMNyefXb9UPqy-ZdqtbZ2QJfmsSC3D4S1jEeVYQXgkoAHCUGe2FzeiQRVpmXFxMemU0RleZnMVfwWPzhNKwumtQYniV4MsLCgMSLnx9i5FQJwnkFWyNeG5K2dTIsEhPBcO88GoXcTST3HsEgKDx1pMbReDJDO67Qql48t8ZkBRUikJOediHInfPFXpkn9afdJeW_qeyWdGc2XVGopZNHG2k5Qt0vfLl_V0F6Gu1kOVUYn5_JmI21flPVtVMbnkDXgTV5xFXQgVFAVKRiRlIwQx5y9-K30l3U69BJ4Rmn4sDO6lYippqVys5jCvkn0BZ41t-5AJbUKU9q-xMJQlUCLOYwYvAV8WARtUF5fK4GNJ_ETZ0AeKghxpMMITYgY46hmWbh3g2QXUoT5V=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                ProductName = "Айва японская",
                Price = 19,
                Description = "Родиной Айвы японской является Япония и Китай, значительно распространена в России – не только в южной части страны, но и в средней полосе. Связано это с тем, что данный цветущий кустарник прекрасно переносит морозы. Даже если его ветки в холодный период года подмерзают – сам куст остается. Название «Северный лимон» Айва японская получила благодаря плодам – ярко желтым с характерным запахом и вкусом лимона.Хотя и по содержанию витамина С этот кустарник цветущий практически не уступает настоящему лимону.",
                //MainImageUrl = "https://lh3.googleusercontent.com/nYl6wQXi2F6ddW4RJstCuo0jpJM4Niel4KISR3KPh-BlYRTIZImB2_-ApCQeepbZSsKsNEgDGgBxUI87fb0Qrpbe1B9dtKi4jpSjEkARPqPVt2LYINbr40Q12Vu3aQ9MUNDDF3Ldg2v7gEtI48Au9ZaU8TUQulh1p5ysSrH7qWkijR3idbgD0FGy5VydBDZ0t_kL3Illv0fCQ0hYHgXlQDqzlKhcRHA8ybBmjmnJu7FRdt_dLexlKrLfwL0sQO9xi_RjRCwpoXv7OOPcq5-SAJ96utpbyLWV6yygrMcYEurmodEQHELTpB3Rf3p4sPGtWQeW_2VIkyw-h8C-y0HKt3A67jwdkwxXBtrX29Ku8vpCgSLc_wasBX2LeJKxvjnSDO0iv2rxFjYgZccSXIq-F8S8VG0YMDz_SCO9bO_An5y9q-U7CJqYYNL9brtffbO4lnvtCVghXmJuQxFbkf73Z9SO9YoGyEteFPf1WzsQJFVERXOqkUS9fDlCkJ9Aqhe-ARt5kKKj9zKZ1ViYAbPVRVeixrQlcFcLuh3N2V6A_3NA91P2JJRMTTa7_ghgYLgSfwnqcE2Jkkf7Kh6hQIrASfsYA-GWKyvV44GqNiSK104-Ee49ER69Y5L6mFDKmXtNuxTMrrBiog5WZB9_7RqN6bI5toJ907jl2saa_6CyZYQRQ7Mhz1xoEqWVg4c0Svr4ZVkPPZzRho0OPhWCWFb_zRxbZY1qh6G8H5mxJ0Ug7KJItuP-24EUUdYgHgwYg1XUhbYW-7x0FzrzJURxFeA-rv8knW2Jfolb3xw118G_y4rqBIuHLWdanNPwPttTTmfAaiSz_98AGIdvSg0tv8NPMdZsYZWZS46vYPQkTh-K0FXyaGFJxKWLh-u1b_1kVsnCmNd2uXiV6SvPJQ4SwzN180qZRxkY_4Wa3mWGMbu_gR14RwuC=w1024-h768-no?authuser=0",
                CategoryId = 4
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 19,
            //    ProductId = 7,
            //    ImageUrl = "https://lh3.googleusercontent.com/4sdCbFS_H1fYtocPmMffFRSAgsbJmm6TxAqnJ0vqk7KZ-fP94EUSXXc2arRrKL0Xye8IL3bVk1mUbC7bLHIFC77ii9VuNZ0frjXp9IZFASZcnIRhM0MdmoWXoMry_QSmXHKsf9k97eq-mRyCUI4HVIaD7yc48gPU5u14O0LRZPue8H16r2gE-kX_AEEQ902wmhoxImbpbGqnmc8t4jrLrB__544IRtgASkfRZ8tza9njpiVHtZJWYXP2QvtVAnF1z6kfvetaHYAvbw_q14WeKYL4uKF4WU57MvV5j8Ec49iElqpv01WIORuOjZklgb-hMkkMe3Ptx2zIVK9rE9U2NPEWNE8eW6kOV0ud812rLt4eF1Yi28Hxn-hrnjs2w2gdWOfjILbl6fSTif6NQp8ZPjjL97LhaxLy3Q_YBPz-SR8OxkTC_Ed5LqiK5hp8KJaujtt70i9GEe7P8xzm8O5sIKWfYCdlLa4RP110qvxMm0VVzrl45V8MYrbrUls_3LDvCFAN6BYB5CFQj_P81Y6yWXmUeZT_HcVeIZkh5UpvB_E1IfzcuWvKnfRHTdmNIBSRgdXM0U-F2uM-94US0BMByMsd1Iu0-5IKWpqjyEh7wRsyHv0HlSPzbmS1SJFk1ScCNwGk89nLNFQIX1dwwg39M2pLehJEI-Y7tQPLVxKXNVRIef02c1NOFeWu07IXB9DMZyjwTRwhg_n65lAcIc4kCvDc4zzc4V8XL-h_QLhwJ7Aq9G_cg8UswljaBR3ERFDX6InE8-IN5zkXOjHDdHulbdPr1g3H6Xh-G6jggMsCHsBcgVWedoydcaBUM1yF2qlNIDWbfj_fcN35jUXDBzilz9sn-YE-gFIYyUDiU_5u4hQQMBjltypYYqAU1fj6jb-G0laowBQommvfVsyYAN1FnO8ME6D8CoMzS2L47RogCNEKtfND=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 20,
            //    ProductId = 7,
            //    ImageUrl = "https://lh3.googleusercontent.com/osI5P-dH6GGTukltasuC-V6tQowtOfXWpPI_gL7r5dzHpWmdcrDvfYtIXBDBxutH8vJPlbjS84AzvqvKIwx0-fmnQsBrwHLcCTQxfjPhxA-G-ZbM3tGdeiwA7aBR6E4WmRmFk86e3bphU4e_NFmP_tsyjYfaY9VUAE0BoIVUNkvHjhC0lb9Uq6yp9Viy6rbHs4_2tJ6ejKlOm3zTjD1uolvi8MKRSs3YXuUwJ2DCFvg5s5YnaZIUq2pN89vuOkQW49MbXvbwirfNuOz58OK12sfCTKKCao90A_NEs4_VlOTG9zcLRQ-I2KD0mZ2bFI4z-MoPX-xzr66YpqDIgxQ7Rj9i6I9W5t115JcQKHlJqgJrIgKAO6dDUB0FOkLzGMjBTbYKJ7Rluf_Xk-CAEdRB5ypxkDsOT0RrRgez-Oh1Zr2kxftD__gZDjkGPZ7Msu8G64KPebz0tlxg7BHlcoB9Gcy0v2I-aXnuWeR6t_mx0SP48cvOos_69Lq4TFwhUDxcemo58PYIK59zhfFxma6tMNoMrjpRyTPjh_Yi5wQ1xHhpeGthfNaOSu8aQWuibvTtfWJieUMsGlXaYRVyXBYGBuuodUEUhH5TCSj1z8QoLEzVdG88mScNtOWPFMuM5o7eLmVTKVXF8Prf26F3eaT2KZduJubarSOe8o0iplMVbiAj4k3oOjArz-FyCF3mZacGBpZcWs6okmDx5DImAbQM25kZXEpBLDE2Z3nyqOAl_rPFup_447b6lUqd28ihV4Q4ir8lZjNkkfL1XHmYSNVSOqLyrTR-ZTpuVqFW7fGX_x2TK9Fq8y0eIicbalfBQmaZpAVnzqeD1DzoHa_M2TrUI-AxQATgLjlOJLn3kTkGwDKrxV7dYQ0QLvd5AUq5pXHrl7tAlWhgMWwOe7p4cn1NIEFqlDV9P9QzermNcqRVDpWYsd8e=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 21,
            //    ProductId = 7,
            //    ImageUrl = "https://lh3.googleusercontent.com/rWzZrh9iK3-_xpuEW5jKG67C3CwBCXZKSuYkoNPu-eE13dAtQnLMqvnLvUjHaaBsdMI1DCJKes_A7NuPXo0Y3414TKoqT8_4rLVLcq-BPIkt5jxe67onrVnhaqINPqVG5MdgQpfdcBjRR6XUgOdnHt3ZxQLcLBXMt4Yb1cFahU1sdvKBI0B1a2QzRJbbUamZcELqGu8CXUbtkCF69iHu5OufInridhwhk6x3rvGLUp81WXc6mLKsRtL14_4JQ7ENqZEBoS40hoaoSKZtLHB95n_tTYgWUNlfAkwDBedELCj3zunbrDXxad8xgUp6nWYa9tLnOaPaojWBKhLsxifPv5p0thuEa7b7AuKd-tZq12Lv7EZXsIZH0DqSkLDrCmYqyrqxyRxB7FrsL3vQgfqbfBPQcp6z5bQ3Iw1p0x7B-gQlOJcYigv_VNOjkcDHRobKZuhRS4bEnI834PVsg5w8FgYZSfE5-wuxjiJYMH9xYJGOnikE4KUP7LUgGFNWRJVB0Qf5bSBnpNj3hst9yiu5K508LIFy-PYO3VxKCTCBmVzmmOI_mfkop7C3oGUY-n1jVMBQpL86u5MzDPSI1YlWfHDnWuQ6MRP3y2wKgQI8jVhWlXLYuHqfISWEQR4OyGBEHMMKTxmsrME9bXJZI43O6L7hu5UCpa-MKOfXPYq9y-027edxiLgk2PC-C4kuBSMzZeYqrYPaOTih14U1Y2KLjQulQVBP8wum9rJqieZBP-0FdlqVNFN8FiRG4HV-SZEKnihTQCQQo5jKN_EoEoQQ5tK4Pl7bL55_RKvawMQPXiRo3K-0e_FL1SWa6ogcgZ8gIZhlxJ4F3RnKSGG4frNPCBk0sqxlKC43X-Z26rS7afzIYR3UOP5vgX16usP7SSvLAajQ_UcPtv6rB_Y8hOnOnSjTr6GlNKriFb1fqVvOvtG-2UaI=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                ProductName = "Зефирантес",
                Price = 18,
                Description = "Родиной Зефирантеса является Центральная Америка. В настоящий момент это довольно распространенное и популярное декоративное растение, выращиваемое в основном как комнатный цветок. Народное название «Выскочка» образовалось из - за интересной особенности растения: его бутоны довольно быстро появляются из - под земли, и если пару дней назад даже предпосылок к цветению не было, то сегодня оно уже все может быть в цветах.",
                //MainImageUrl = "https://lh3.googleusercontent.com/Arb4DdvCALtuP-BUirYYpKw8l7yxCq-vjqrM7AtLtw7UWJj1dogeg5BhtiWpGr0GkIhJE--F640tSwJraM3DCO-_JSilRTVZqlb8MDfwn72rIfMNW3EYRLj0ZGTyxFlKxBTKG_8usIUg14mAessY3_xcrUyfIUzVqqgCJmDl4FaVb-8oKXEEi07nHYR4MMU_g0nqcBBV6hmST57NpIiJ9nSAREtFhgSWdKS7t5Y9P8YESvsO-MtxJrKGpqjuw8CCw9_eqpxhQ-2DJ5gjRJIgO3Z3Ec8_tBnlxWa2Qu-m_vrv5zueFycK3lyXWFBt0gtueMSK7GY8zTyP6oc2BUjnRWTRW4aokhUbC3ZKa9POsmOFMvOB9KY2qKgBGs-HP4wy_vcVsrm4aJr72kTV-UG7VMuN4VYSEJ82a9Ka-zjn8xZ1LJ5T88qkfTg5nZsOTi49ES6slPdYEf5qSSwlpCRG4KIN0tfw70YwQ2DX555iPB8Ns-RgTdcr_jTZpDqdbacjC-gRPxUHLoQHJi5aHbyqhHDhzD5tqZuZbeUvGU0fCiHBi0MPIpqZRo94KHAgQAhWKfAzRdoWRPFkfK7VpI2IVuiehbyml_MB6osvYDpxGJ9ckwTytIWK7X6z0XPrDUISvJJ0cSdTuSjPhl4L8P1pz5ZLXmJd0hXPr16zA1N2pb-Yb_hOftaVntmpKlPJ5rs9h-PhqMIcDtJN1t8NYKg452F4vGnY_hgu9fRAV5wjDSJVm8wtD3pAc3Ww3Nyh-shBLYo1H3wo_ux3PlJnGT-3VOJ_8TmiwUzZydrJPlZnzDyYRaAOkYi7HBPuF9Lh9o0C_TQ4IgaAL2k_blKZ_oci0_-ZSC51-JVKhBAcvhBwdJNW3apFphmXgD--WaRt_j6QWqL-4XY53i8ZHUpZQrKBtSZUB9gvTpvmG4OqSItnoVCtq9CU=w1024-h768-no?authuser=0",
                CategoryId = 2
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 22,
            //    ProductId = 8,
            //    ImageUrl = "https://lh3.googleusercontent.com/3Br3gDckSbD1GCeDlXREzqDkrK7MSIuk3LebY9Lf8GH8MYnZ_eliJ2gcZ5-9DttZT_JpR-4LiRLKQHxAb0iFI9YK7zH8dvlB2_1rlVBp6DUQ6BLxe-ftz8rOYrTRlsFp2N1I3UBJS3xpOyDqWQTLUDwBcaYDx7M6NsoH6JSxGT8E-apwMQxbrzOZwjbY4KsiAk4Kncmru9X230B--iVt9tGriMnhFxLfL1djVwUkpAbA2m4E--h__XQmLFpJQ9pPdQ9WmVxAP1ijbgHbjGhKDOj2vMXP3ScFKOeP4YaXII7m7fg3BQLOL2iR_Xp3OY_u26Ku-8vlgwK526EBQh3dsx88HmH-tZXkyrNL3M9pfJkLYPqPl0lLWfRGXkzvzJILmlhcXjai3FY69OxdPi4oUX-fAqNXd0UqonxcfWKLohLKAljP9UfEhkZyu440ZiDslXdXXTsl01xGz01ZzyN1FEhFy-hdnoqupb1v-scNZI-irHHd1U8q2AHsmh7eQK-IeZgBPf3aP7L3nTt_WQ4rjegqIf014JZ0eXB-y7rzdwM6CpAG0XnQcfjBIM8mXYlUZ5U3wwyqltCVMwgoIwet1g446jcDUH54ZuTCxM7q3m2Ch7LXdRvug7EsROZ_pDKdnLceUp3T2Iu4U4fpxDBLesYcZ7V-GYcHf16TgIFN5zjtaqbcuGY5LbIMyY0TTn6Pk-MWsylo9zoOwxK70ndcX5DT_YBCagQlE28b8kFjagQxEtJGNEV875iq72lF_wQbhpA4iLH5C2lClEIKQXjFg2KLtVS8epZ0TmpoMrUEcgYHO_7ZnX9VmP287X9czsh_cgaB3fdEJ8z0vgXjywYrYdxhOJMlqSuf_XDbRFUAjkX-ynE1ZU-prMYkQC2UUYIqdm3ookpSfczZTEN3-edDj_zb6ltT3yznRkGxMbnySK2pflVU=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 23,
            //    ProductId = 8,
            //    ImageUrl = "https://lh3.googleusercontent.com/2ac9padv2O0Xj3gRAF4-B1D6KXBluN2-8yw6bxMLAutsmaVNbNK4vehD0nvDTMtd_73n-61H9ufdThUVn8XASy76dGoQA-GS0eTK8H03XjxMg6FGY2ci6_8qKFuZHd173T-aSCz6ksLAw5pRGSOD4NzUT7GTCZeEHlhhVjqUdJOwvxGKUTYnEY-TDkls6XY5TNhgOCI3Fcl5NynPEiad7l95KI0ftfR2CdY-RfYgvR8mXg46nhIK_m96PpykYB-cjBfkmP5Xf5LCroPRLwo4KoiX75wh9s_NAfd2vOJb730nExtNf5wONSeSygzZ9SL3Uz_Vmjvt6EzgzkDqlXdQVQAXg8kzvEIFLXdlAZwLqZFINfib4RffSYaMRGAN3FTIhHa864R6KF0ZhPhHhesBT7kthnm9ofDgiJO4x9-mtGoOTV_hIdkRjynDMl1Sw9K3uEmwPJ8kb_ijzj24JXRZ967g2FBBdIVxF3UR-lzE6xtjkNYlPGooLa2nhnmHoeL6PvGbyk4ca5cmksA6dXnnbAxvrvvA3VWvaPIJc1VRHl-GXmBD2oHH73QzcD-_5GMRr8NIripfEwXKU1BRTg9h590KUaE0AQi5Cn3Lpq-xemFFsPS7ajcMAs0Oowc_zm30cG4z91zYcOcZsFFE49SdlyKMVBCTZ42gFB4v2W7Q4crEQYpP9mzJDzKtnIZBY0Q_5bCih7eBUZVS-5S_C6ybsiJ4QEiN8QgI9VHmFJrF_PbA5SAmC8DpyfBPkNdGL9RtuGcfDEGYvY7-m4MwAy2WBUABEfnkPIUcWEkGVNguFq2RNXUHFVP0ADhlwzB2JI-FBTYPzBJ52tngr5dVPpgi1--sjOSsr3ocsx7DJUraVxyCMmnrHhlmos_6cowtPWrbkIu_PqQnQrkxAevB9uexb-6QOK8W35SsVI8oc24LF0RABHWe=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 24,
            //    ProductId = 8,
            //    ImageUrl = "https://lh3.googleusercontent.com/1jAtyCNdv_7hx1xoeFBwiUpPqCaXLnrO6sv-Pzhla7q_YeQgRh9Z_PYgxZMKu8Q3KsrqOkgK6P2lxRIFZ11J4mX0U6Atb4Y8d78tKF-bwPK688NEtqvvQh21yU3b9zsH8bmRsSKsTUJH8Q4kBB9CTxg9smj2-um6x3DafMRrMrPXzOtnKfnFQ3_AGDcgrkjmfyC4Y0dZ62_d4SNFyyeKoUL9BylU8HBjtZnT18WgcBp4JnypLPkTl8jdZukMFYxFM3DQyFIIYgcVYjD85-FYg4VENVkSqTOsuRZixhlFsOsHJJseXalM_qqOKBuiwPoVphL_uyNoGSVdUtZVurkjq-stRhlBP_f1NUY97IYdeA-P3dxDvhUVJzkp3yuYh5NCciyD3NVu3X_kIaxfoYXx0cNfm9L4zpPQeheS-taJYGcKzgL089TS7U2TH0CNzwORscKNe2oceKDBPBjEP00o08E0ZyVF3k8VMYbxaVS-47GGQgKuQqRJFF_W5RdpaqJ4hzJ3IaWY-BODCGrrKR0o_0QHRw4kxfijECKqfX8CBNSd3EtWCzavf8ACx8ofDfiZBAuXR8AxQORXOLEeE0KEBLsJYi2sS21WMEXM__tfW9igtn9IoiS1rw6hgtGURh2y05p9vth5ifo_iY2vj6-zoFHpITomgi1xzL6BFPthqUWbmsaeLSijj6eGiaZ6PG_0jUraioaiQAcm8wAfNPePliiCltavdYMAUWLPYQwkg5Eljgt7CLr5TzSx4gk8pWiYhNGvZ38aN8Zf2V4TPzoMqngAgLWa4UuyMLro4wLjL0_lshh3XU-4yGWy1BcCZ8xaUG41t73qZsNlUfyqM7QdC5YOXbnWTxOilegwOrHbS40jtZavZ23VYmkgIGDeoGpcYu464lXcDmDBw3kKhiu5_JlXaWdToR9S2kdoNe5vT8srSNLr=w1200-h900-no?authuser=0"
            //});


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                ProductName = "Колокольчик",
                Price = 18,
                Description = "Название Колокольчика произошло из латинского языка, в дословном переводе означающий колокол. По народному поверью, цветы Колокольчиков один раз в году звенят, происходит это в сказочную ночь накануне праздника Ивана Купалы. Колокольчик – травянистое растение, имеющее более трёхсот видов.Наиболее часто цветы встречаются в Европе, на Кавказе, в Сибири, Колокольчик предпочитает умеренный климат.Растет цветок в полях, лесах и лугах, встречается также на скальных и пустынных участках, некоторые виды также растут в лесу.В последнее время Колокольчик активно высаживается на садовых участках..",
                //MainImageUrl = "https://lh3.googleusercontent.com/XWDzFNY3mxG1MMT_ySzs50vx3GlZAV_v-WoWTa2IVV1NUMT_3oFgG1gHwqOATE19dXTP-uXL-8wrOeGc7_IY_do3giaw6-Rhj--Kr6-m8dZyw486mmRI5ohx4fZoAGE_EISM1H-X8JN9gXOdApmcx8D4XF4VCqn15VewxL6YayerlKgj60H9PvVkMSTx1ComYJyNNnTuQ7pdVGNt6bY775gypxB8RrnXIiq0qo5Oezf7l7_FgJzl9Zw8nFh_3aEpkNfl8QWTU3wsnx7EGLvg0bQAukK6z-GnLqV51ewFflgoJJ00TFQM6ZpLZk7cbSX1q_16JXfzer6q9bT5UEySJFWPTfM3Fd8_6K2AgGuOT_4nZfG7vNqefOqEBtSg3hNw19zwZGfGSZJlU994ZTDyCQyn-iFQ_OulhV6BszXjVGkS9yzRfSJPwqpQECTtYS7jfyPSq_rC-vT54vhXPfXgi8PG1iOG9Yh1PLiJ0yksqdrnBpGcjbdoNNfx18azHV2TGVEmeX0Y3tuxbZxNyZbYd-91YmPjOA-eVZ6FaMvTzSmn-hAA3kbkX_026LT9zOa6R2hXmfXiMMNe4k1AEMrGH8My4uwBc8926tO6NI53j9JY83fftI3-sSy4dGjDtbIMWIjDCuXim9criyKoVBnnFV7A2mYZTapSUyZQRXNiooQkEBK2xgPZHPKCJMCppskUIwf07tOolGYUKkLXPrQV8_GYq2NbQN6n_TMDkFFWjcfpi4mEv6vCY9pKIg0NoBooFWY6wCQxcIyghP7gMFUEcUL7ool2NP_XislrvGjSX0pTKJPAA5KQOwMrACBFZgr30UJHM0cro05MNjGb8TEARn5BSeBoPcqGipr3QOOhqh_TxupPxxljtIxo-L48pBemfahFx4Y-qEutScqETKrKxK3W_2Lm-iILp_b6idf-Njj4DeKu=w1024-h768-no?authuser=0",
                CategoryId = 1
            });
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 25,
            //    ProductId = 9,
            //    ImageUrl = "https://lh3.googleusercontent.com/bwNdf5BrGBJxyUuzuhfHfbB01Cz8RYBEcNAEJMloaysbN0ZGjdCxIitZgcFRuX3iF8BjggyUV7mx2AUpikQdRGs7AoGkPMoxXU_0ojPgfzgKqr6aka_DMZk4xEZbyqddCEa-cJrYSMvPSCpLEC9ly1QIX6KpTYIeZJhBbbO8IYgsnbk_xQND4gpEbEKeChRl3iExbw7_jEXjTxMKgVdCb6f_n8mT2wLMCFlFfuCVgMpLzmslUE3MpEA3sWxdBEmffqR98yWqau2U9cmEkO0mBNQP-AyA7RiOQETEWSqahTiTMMJ55GBB74uQVpIQPdpHqcGsEODMAyALV6t8BeETiHTZc1SfTC1STZlAW3CobPPKND9db4fqTQBqRE7WyOHl7FnHiaomCAdGXvXxQvc97kJutXWEtHBkmB0CBdOHsY3pzIoQKXm6Pn6nH7AwCXXbBYHGpZFaT7DsG21Pfp757jCha2daDHCzaVXy3KMLtSMFO59P_819CXKh-0DwTMKAQG1Mw4i-VxTMSW5d9RlbNtooo_vLw--GeRxhx529zS2hdBjBNvbXOPzRRZuuXDFpyfj1UWcMr0ZXIXcjxiTp_TnG_fNpAQqKTCV3dLhaNJqwWL0ATlckacXDLZKt-7Jzg5zbpphHIrrjMhhNHgMj0WXm05gBFY0O-2PZQU72j40Csu07Jg7seE8qO4IngT3qFG5vTbxt3KDnUDUntO6IjUIEydrruYy4cZWy7AVn0WRjUnrSq8JjRP8CPBs_rCA8g-PHgqVQTblC6SQqIyfmT4oE2lpqGJ1qAY3L2YzgsRn8i3mxm74OkyFSQeoCpMKbexKxmCgFneoprXa0ruKpc8bohgZHkdNj3SK4qp8FS6lOii7jEmiwaZAVI8Ua19renLtAGkuEa9w2w7o6FInR7903vDHM9UK_9Tlhq5-VnqDgOPJb=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 26,
            //    ProductId = 9,
            //    ImageUrl = "https://lh3.googleusercontent.com/cXUyOOc4_7CYca6qCKLE2JrrBVVM9FReilnJOppyHHjLDyhU42QuhJXxiiID49IJTEp-kBjYVX0Cr_g4-sOBzlnmrc8igcBO9x141eq7pRxz5sjp8CN41Oa6t_IXUiRET6vdqGShZnaWWpI_vN8T8j_nwzcDdubVuw1noeZMHTy_tMawOiJXCOqBJgBaMRb_ykvw-qTdaydVYPBWu9ZbWXcz4oYFz3mhDNJjw0W_PBlrA-HlNaPQL0qMbZxmOljnSEw_jKCAnWgY0kuIfNh1Z1Cayfgfg-KAIwxenKmjaU4-5wWDGzCWUR0Euf7jx_OmNhoPkyZTuloHREZjfH_vhd9PtzzBDDnsdrdoHUEs1pXleVMoJtksDghOqTSE3VQ91qEslJn01F7I171N45zHe8KpDodHAIh-oS2SZfJlh189XxRRNbjjYNc7bwiNJBOyg0tEosgiYHBQrIshoPx97-5dqaTLjBZaJbblrLQAqPbMlx3SHAsHIhXKx2_qE0IHnWEIcUgebQ4t7jtE3LTA9QsRYKGGmtIEPhd39jVgHXuCWkphzjb0b46SiZ5NcFjLFCsOCkqV3IDr9poJBTv5WKlHr0LMp1yBEL-CZyl9wMosM8y--Ai0jREeMwEt165ck8JAgQzxLJ1GpT0IVtbToG4p6NuQTD5EvnGDZ00Er2oO94bUXnrzxnr8boH9bUNEEKfT8nhyl_L7-VCO7TUqVMzAARiK0FASmxSbq90uCALknRhGXPXXDczHF2TjKxziaHlE0U6SLnHBEFw4M26L0a2P_9jNBFrQwqLy9kk1jgp3LTjelqA7Sr1QJvEs8ouCEgqHlmyptZx_bbb36D_3R0N-M0qqnqEZ2c6VHgvWhQJJxa02HcKRmoL7n5OI9ui9T_JmKLOABWIURQDWIhPVnY2QRuTj2v9Xoj7b0hCJz16GPo5a=w1200-h900-no?authuser=0"
            //});
            //modelBuilder.Entity<Image>().HasData(new Image
            //{
            //    ImageId = 27,
            //    ProductId = 9,
            //    ImageUrl = "https://lh3.googleusercontent.com/w0jJIUDWn4_H3ZK6bhaC-1EvKGXwClGfIN-HyN5lNNAxqTMd1Sl8-s9WLZwg9vpKiz8WdSsmrC9TcLNINCd01a1DoIh3jNKqIRVGSz_8ZKTPhiv4TRgOrN5DQlhmBct8RuSo8PNMqGutDEVq3-s5y9svu92bouXBj5SSxjbk0ACva7SuVlT4-qOkYo4OlVg4pHVF_MhGOG1EBPamqjETAqWAbFW5AnG1JqrRrhCcwaQaVxGjuwdf175rPl7H7VmmQV4j_T-WidtzyxoOc-SYyP336WvO3gE6gMdIHFCUQxvpvUuop7uRHddHwiCsavjYH61KrRmupF2qX8LUW6bgFqc8qvMbjtv1eJVXSUio3h26ajTcOCJNNCSle9Sm1qo_OO35HZ5liNdFLOSaXwi1NtMOtx2jR8WVnquu-FP3-2P8R6RLKCzQ3dW8LWk0-IIjmo66H3wv8vV_E0dLq3hbQT-bqOiX38cnQeUhL-dTiNnBsMyj7xVWK9DvpbYCWxFriQ3RUKLXN8TKj1HyV0mI2IRKb_gDuVbcqcm63OiRlWdfPjzvBXuQsor2XKqzQ7EskQk2rFm4xI82WA5x2bD4U_T5yUI16hS48A3XwYGEE4QL9inaLsbGS8-chdJ1GdxmmCNP3HTW5Hjpzz_RiPeDib7tLLYw6pRnWEwzedClxYTVmMYND9cYh7BTwpd-Kj2aDnqU-TCZH1mT3msDVJP45JLVjv-INSDtZDYC9kLoqiIKyCpxKY1P8NMzTP9sJfDOfSUkRaGKnPvFTTI7DF33boiCV4i1R7nMw8gqH4ijYuaQ3AaRF0EY_d2X5qhOEXg_kg69YzCdxpsGURNXYfdaVDWU_r348YD9MmZl6YXOBCUkibVRwFI4RHRnsQUbD0-bjdKsCfNQwRVK-UnHjDNXYLm7BuSh8XUiJv4dMTAkurGffVt6=w1200-h900-no?authuser=0"
            //});
        }
    }
}
