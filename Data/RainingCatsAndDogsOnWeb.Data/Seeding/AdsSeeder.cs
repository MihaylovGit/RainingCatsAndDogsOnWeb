﻿namespace RainingCatsAndDogsOnWeb.Data.Seeding
{
    using System;

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RainingCatsAndDogsOnWeb.Data.Models;

    public class AdsSeeder : ISeeder
    {
        private readonly ApplicationDbContext dbContext;

        public AdsSeeder(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Ads.Any())
            {
                var ads = new List<Ad>()
               {
                   new Ad()
                   {
                       Title = "Френски булдог",
                       CategoryId = 2,
                       Location = "град Нова Загора, област Сливен",
                       Price = "550 лв.",
                       Description = "Булдочетата са родени на 08.22.2022г три женски и две мъжки за едното женско цената е 550лв обезпаразитени с поставена първа ваксина.",
                       AddedByUserId = "1442cbb7-1a4f-4974-b72b-d4838e88ef70",
                       OriginalUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_121038187_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_121038187_big.jpg",
                               Extension = "jpg",
                               AdId = 633,
                               AddedByUserId = "1442cbb7-1a4f-4974-b72b-d4838e88ef70",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_120928384_big.jpg",
                               Extension = "jpg",
                               AdId = 633,
                               AddedByUserId = "1442cbb7-1a4f-4974-b72b-d4838e88ef70",
                           }
                       }
                   },

                   new Ad()
                   {
                       Title = "Продава Самоед бебета",
                       CategoryId = 2,
                       Location = "град Плевен, област Плевен",
                       Price = "300 лв.",
                       Description = "Чистокръвни бебета самоед момиченца и момченца на 3 месеца с 3 ваксини + бяс.",
                       AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                       OriginalUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_121038187_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_121038187_big.jpg",
                               Extension = "jpg",
                               AdId = 634,
                               AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                           },

                            new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nel_1978/8263424_120566902_big.jpg",
                               Extension = "jpg",
                               AdId = 634,
                               AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Английски пойнтер",
                        CategoryId = 2,
                       Location = "град Плевен, област Плевен",
                       Price = "310 лв.",
                       Description = "Продавам на ПРОМО ЦЕНА Английско пойнтерче. Кученцето е родено на 26-Юли-2021год. Обезпаразитено и с поставени всички ваксини!",
                       AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                       OriginalUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941417_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941417_big.jpg",
                               Extension = "jpg",
                               AdId = 635,
                               AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                           },

                            new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941405_big.jpg",
                               Extension = "jpg",
                               AdId = 635,
                               AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                           },

                             new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941407_big.jpg",
                               Extension = "jpg",
                               AdId = 635,
                               AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                           },

                               new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_116090787_big.jpg",
                               Extension = "jpg",
                               AdId = 635,
                               AddedByUserId = "51835588-8d47-4943-a52b-bb969225d6ee",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Продавам ТОП Кане Корсо чисто черни",
                        CategoryId = 2,
                       Location = "град София, област София",
                       Price = "500 лв.",
                       Description = "Чисто черни Кане Корсо обезпаразитено, с втора ваксина, от родословни родители, родено на 09.09.22г",
                       AddedByUserId = "5d00e771-1bed-4fa1-a55a-f88732435143",
                       OriginalUrl = "https://www.alo.bg/user_files/x/xilari/8397216_121082493_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/x/xilari/8397216_121082493_big.jpg",
                               Extension = "jpg",
                               AdId = 636,
                               AddedByUserId = "5d00e771-1bed-4fa1-a55a-f88732435143",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Мъжки Мини Йоркширски Териер",
                        CategoryId = 2,
                       Location = "град София, област София",
                       Price = "250 лв.",
                       Description = "Предлага мъжки Мини Йоркширски Териер. Ваксиниран и обезпаразитен, европейски паспорт, микрочип и здравен сертификат.",
                       AddedByUserId = "5d00e771-1bed-4fa1-a55a-f88732435143",
                       OriginalUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011010_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011010_big.jpg",
                               Extension = "jpg",
                               AdId = 637,
                               AddedByUserId = "5d00e771-1bed-4fa1-a55a-f88732435143",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011011_big.jpg",
                               Extension = "jpg",
                               AdId = 637,
                               AddedByUserId = "5d00e771-1bed-4fa1-a55a-f88732435143",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Кученца Белгийска овчарка",
                       CategoryId = 2,
                       Location = "град Елин Пелин, област София",
                       Price = "330 лв.",
                       Description = "Продавам кученца белгийска овчарка с много добро родословие и с поставени всички необходими ваксини",
                       AddedByUserId = "7e11a0ce-641e-4e3c-b57c-dbac747a7b63",
                       OriginalUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011010_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011010_big.jpg",
                               Extension = "jpg",
                               AdId = 638,
                               AddedByUserId = "7e11a0ce-641e-4e3c-b57c-dbac747a7b63",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011011_big.jpg",
                               Extension = "jpg",
                               AdId = 638,
                               AddedByUserId = "7e11a0ce-641e-4e3c-b57c-dbac747a7b63",
                           },
                       }
                   },

                    new Ad()
                   {
                       Title = "Чистокръвна немска овчарка с три ваксини",
                        CategoryId = 2,
                       Location = "град Ямбол, област Ямбол",
                       Price = "300 лв.",
                       Description = "Момиче на 3 месеца и половина напълно самостиятвлна здрава, игрива енергична обезпаразитена вътрешно и външно с три ваксини и медецински паспорт.",
                       AddedByUserId = "8efe2038-4ed1-4604-bf04-8fb1256a8ed7",
                       OriginalUrl = "https://www.alo.bg/user_files/p/pep_inoo/8334548_120672013_big.jpg",
                        Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/p/pep_inoo/8334548_120672013_big.jpg",
                               Extension = "jpg",
                               AdId = 639,
                               AddedByUserId = "8efe2038-4ed1-4604-bf04-8fb1256a8ed7",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/p/pep_inoo/8334548_120672015_big.jpg",
                               Extension = "jpg",
                               AdId = 639,
                               AddedByUserId = "8efe2038-4ed1-4604-bf04-8fb1256a8ed7",
                           },
                       }
                   },

                     new Ad()
                   {
                       Title = "Продавам прекрасни малки самоеди.",
                       CategoryId = 2,
                       Location = "село Костиево, област Пловдив",
                       Price = "600 лв.",
                       Description = "Прекрасни малки самоеди се родиха на 22.09.22. Има 2 женски с розовата и оранжевата панделка другите 5 са мъжки с другите цветове панделки. Съдбовна дата кученца на шампиони, майката и бащата са наши красиви и родословни родители, като бащата и дядото и бабата са носители на първите места в киноложките изложби с много медали и купи. Кученцата са вътрешно и външно обезпаразитени и захранени с първокласна гранула. На 45тия ден ще бъдат ваксинирани и ще им издадем здравни книжки след което ще могат да зарадват своите нови стопани. Повярвайте те ще внесат в дома ви много любов и топлина.",
                       AddedByUserId = "b0405145-2527-4d47-935b-1bb69003b6c5",
                       OriginalUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038234_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038234_big.jpg",
                               Extension = "jpg",
                               AdId = 640,
                               AddedByUserId = "b0405145-2527-4d47-935b-1bb69003b6c5",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038246_big.jpg",
                               Extension = "jpg",
                               AdId = 640,
                               AddedByUserId = "b0405145-2527-4d47-935b-1bb69003b6c5",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038277_big.jpg",
                               Extension = "jpg",
                               AdId = 640,
                               AddedByUserId = "b0405145-2527-4d47-935b-1bb69003b6c5",
                           },
                       }
                   },

                      new Ad()
                   {
                       Title = "Продавам мини пинчери",
                        CategoryId = 2,
                       Location = "град Ямбол, област Ямбол",
                       Price = "200 лв.",
                       Description = "Продавам 2 момчета и 2 момичета, бебета родени на 27.09.22. Едно кафяво момиче и едно черно. Момчетата са 2 кафяви. Обезпаразитени са. Хранят се и с гранула. Намират се в гр. Пазарджик.\r\nНе отговарям, на чат. Ако някой се интересува нека да се обади на посоченият телефон",
                       AddedByUserId = "8efe2038-4ed1-4604-bf04-8fb1256a8ed7",
                       OriginalUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133817_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133817_big.jpg",
                               Extension = "jpg",
                               AdId = 641,
                               AddedByUserId = "8efe2038-4ed1-4604-bf04-8fb1256a8ed7",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133819_big.jpg",
                               Extension = "jpg",
                               AdId = 641,
                               AddedByUserId = "8efe2038-4ed1-4604-bf04-8fb1256a8ed7",
                           },
                       }
                   },

                      new Ad()
                   {
                       Title = "Продавам малки котета Британки",
                       CategoryId = 1,
                       Location = "град Варна, област Варна",
                       Price = "500 лв.",
                       Description = "Малки котета Британки, късокосмести. Момчета и момичета.",
                       AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                       OriginalUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133817_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133817_big.jpg",
                               Extension = "jpg",
                               AdId = 642,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/o/ovanezov/8186703_120850725_big.jpg",
                               Extension = "jpg",
                               AdId = 642,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/o/ovanezov/8186703_120850726_big.jpg",
                               Extension = "jpg",
                               AdId = 642,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },
                       }
                   },

                       new Ad()
                   {
                       Title = "Продавам британски късокосмести котета - две женски",
                       CategoryId = 1,
                       Location = "град Варна, област Варна",
                       Price = "400 лв.",
                       Description = "Котетата са две женски - родени са на 29.08.2022г., вече изцяло захранени с висококачествена храна (паучове + твърда), с изградени хигиенни навици. Много сладки и игриви!. Майка е много кротка! Бащата и майката са с чисти расови белези (може да ги видите на последните сникки)! за повече инфо, моля на телефона!",
                       AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                       OriginalUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_121054586_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_121054586_big.jpg",
                               Extension = "jpg",
                               AdId = 643,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_120869479_big.jpg",
                               Extension = "jpg",
                               AdId = 643,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_120869476_big.jpg",
                               Extension = "jpg",
                               AdId = 643,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },
                       }
                   },

                        new Ad()
                   {
                       Title = "Продавам Бял Екзот - Персийка",
                       CategoryId = 1,
                       Location = "град Варна, област Варна",
                       Price = "850 лв.",
                       Description = "Бяло, екзотично късокосместо коте, момиче, с родословие. Нашите котки са закупени от най-добрите развъдници в света. Те са международни шампиони на много котешки организации. Нямат генетични заболявания, защото имаме направени изследвания от сертифицирана намска лабораория и издадени сертефикати за това. На последните две снимки са награди на родителите.Възможна доставка в страната. Лиценз №150 от 08.04.2019г. Професионален и лицензиран селекционер, с висок стандарт на грижа, поддръжка, груминг, състезателна дейност и хранене на персийски и екзотични",
                       AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                       OriginalUrl = "https://www.alo.bg/user_files/b/balkanavista/8285098_120866724_big.jpg",
                        Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/balkanavista/8285098_120866724_big.jpg",
                               Extension = "jpg",
                               AdId = 644,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/balkanavista/8285098_120866725_big.jpg",
                               Extension = "jpg",
                               AdId = 644,
                               AddedByUserId = "be0117a2-670b-4500-a805-1272aa6f990a",
                           },
                       }
                   },

                         new Ad()
                   {
                       Title = "Чистокръвни Британски котенца",
                       CategoryId = 1,
                       Location = "град Пазарджик, област Пазарджик",
                       Price = "500 лв.",
                       Description = "Предлагам чистокръвни Британски късокосмести мъжки и женски котенца ( British shorthair) от елитни родители, с доказан произход. В момента на вземане котета ще са социализирани, обезпаразитени, с проведен обстоен ветеринаромедицински преглед гарантиращ безупречното им здраве, научени на котешка тоалетна, самостоятелно се храни със суха храна премиум класа, и е научено да си остри ноктите върху специални уреди предназначени за това. Добре се разбират с деца и други домашни любимци, големи гальовници, с добър нрав. Цена 500 и 600 лв. При покупка ще получите съвети за правилното хранене и отглеждане на вашия домашен любимец.",
                       AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                       OriginalUrl = "https://www.alo.bg/user_files/k/krot/7524850_121224346_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/k/krot/7524850_121224346_big.jpg",
                               Extension = "jpg",
                               AdId = 645,
                               AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/k/krot/7524850_120924476_big.jpg",
                               Extension = "jpg",
                               AdId = 645,
                               AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                           },
                       }
                   },

                          new Ad()
                   {
                       Title = "Персийско късокосместо женско коте",
                       CategoryId = 1,
                       Location = "град Пазарджик, област Пазарджик",
                       Price = "200 лв.",
                       Description = "Персийско късокосместо женско коте на три месеца. Котето е с изградени хигиенни навици и е захранено с висококачествени храни. Обезпаразитено. За повече информация на посочения телефон!",
                       AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                       OriginalUrl = "https://www.alo.bg/user_files/t/t1gt/8405403_121135746_big.jpg",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/t/t1gt/8405403_121135746_big.jpg",
                               Extension = "jpg",
                               AdId = 646,
                               AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                           },
                       }
                   },

                               new Ad()
                   {
                       Title = "Шотландско клепоухо коте на 2 месеца",
                       CategoryId = 1,
                       Location = "град Пазарджик, област Пазарджик",
                       Price = "400 лв.",
                       Description = "Разкошни шотландски клепоухи сладури,\r\nТъмното таби мъжко на 2 месеца и половина. 400 лв.\r\nСини и лилави - 600 лв.\r\nКотетата са обезпаразитени /вътрешно и външно/, захранени с висококачествена гранулирана храна и с изградени хигиенни навици, приучени да острят ноктите си на драскалка. Породата е символ на спокойствие, достойнство, самообладание, чар, стил, аристократичност и домашен уют. Притежават мил, благ, уравновесен и гальовно ориентиран характер. Те са умни и чистоплътни животни. Безпроблемно съжителстват с хора и други домашни любимци. Дружелюбни и ласкави. Лесно се привързват и обичат всички членове на семейството.",
                       AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                       OriginalUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043539_big.jpg",
                        Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043539_big.jpg",
                               Extension = "jpg",
                               AdId = 647,
                               AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043533_big.jpg",
                               Extension = "jpg",
                               AdId = 647,
                               AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043537_big.jpg",
                               Extension = "jpg",
                               AdId = 647,
                               AddedByUserId = "e65efaa2-d9f5-4f3a-9550-810113585905",
                           },
                       }
                   },
               };

                await this.dbContext.Ads.AddRangeAsync(ads);

                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}

