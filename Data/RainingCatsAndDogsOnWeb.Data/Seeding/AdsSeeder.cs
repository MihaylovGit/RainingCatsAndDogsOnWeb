namespace RainingCatsAndDogsOnWeb.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RainingCatsAndDogsOnWeb.Data.Models;

    public class AdsSeeder : ISeeder
    {
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
                       Price = 550,
                       Description = "Булдочетата са родени на 08.22.2022г три женски и две мъжки за едното женско цената е 550лв обезпаразитени с поставена първа ваксина.",
                       AddedByUserId = "0643adf3-6147-45b8-a858-5ba14432978c",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_121038187_big.jpg",
                               Extension = "jpg",
                               AdId = 1,
                               AddedByUserId = "0643adf3-6147-45b8-a858-5ba14432978c",
                           },

                           new Image()
                           {
                                RemoteImageUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_120928384_big.jpg",
                               Extension = "jpg",
                               AdId = 1,
                               AddedByUserId = "0643adf3-6147-45b8-a858-5ba14432978c",
                           }
                       }
                   },

                   new Ad()
                   {
                       Title = "Продава Самоед бебета",
                       CategoryId = 2,
                       Location = "град Плевен, област Плевен",
                       Price = 300,
                       Description = "Чистокръвни бебета самоед момиченца и момченца на 3 месеца с 3 ваксини + бяс.",
                       AddedByUserId = "1ca3034e-4bd2-458c-8b8b-beecab427516",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/i/ivan19/8375464_121038187_big.jpg",
                               Extension = "jpg",
                               AdId = 2,
                               AddedByUserId = "1ca3034e-4bd2-458c-8b8b-beecab427516",
                           },

                            new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nel_1978/8263424_120566902_big.jpg",
                               Extension = "jpg",
                               AdId = 2,
                               AddedByUserId = "1ca3034e-4bd2-458c-8b8b-beecab427516",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Английски пойнтер",
                        CategoryId = 2,
                       Location = "град Плевен, област Плевен",
                       Price = 310,
                       Description = "Продавам на ПРОМО ЦЕНА Английско пойнтерче. Кученцето е родено на 26-Юли-2021год. Обезпаразитено и с поставени всички ваксини!",
                       AddedByUserId = "1df873c6-32f9-4a42-b208-dbbd44c7aced",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941417_big.jpg",
                               Extension = "jpg",
                               AdId = 3,
                               AddedByUserId = "1df873c6-32f9-4a42-b208-dbbd44c7aced",
                           },

                            new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941405_big.jpg",
                               Extension = "jpg",
                               AdId = 3,
                               AddedByUserId = "1df873c6-32f9-4a42-b208-dbbd44c7aced",
                           },

                             new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_119941407_big.jpg",
                               Extension = "jpg",
                               AdId = 3,
                               AddedByUserId = "1df873c6-32f9-4a42-b208-dbbd44c7aced",
                           },

                               new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/markas/7555157_116090787_big.jpg",
                               Extension = "jpg",
                               AdId = 3,
                               AddedByUserId = "1df873c6-32f9-4a42-b208-dbbd44c7aced",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Продавам ТОП Кане Корсо чисто черни",
                        CategoryId = 2,
                       Location = "град София, област София",
                       Price = 500,
                       Description = "Чисто черни Кане Корсо обезпаразитено, с втора ваксина, от родословни родители, родено на 09.09.22г",
                       AddedByUserId = "5c8ceb7e-389e-478b-86aa-a126a73eda9c",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/x/xilari/8397216_121082493_big.jpg",
                               Extension = "jpg",
                               AdId = 4,
                               AddedByUserId = "5c8ceb7e-389e-478b-86aa-a126a73eda9c",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Мъжки Мини Йоркширски Териер",
                        CategoryId = 2,
                       Location = "град София, област София",
                       Price = 250,
                       Description = "Предлага мъжки Мини Йоркширски Териер. Ваксиниран и обезпаразитен, европейски паспорт, микрочип и здравен сертификат.",
                       AddedByUserId = "707c6cdb-844a-43dd-b952-941c52a0bda2",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011010_big.jpg",
                               Extension = "jpg",
                               AdId = 5,
                               AddedByUserId = "707c6cdb-844a-43dd-b952-941c52a0bda2",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011011_big.jpg",
                               Extension = "jpg",
                               AdId = 5,
                               AddedByUserId = "707c6cdb-844a-43dd-b952-941c52a0bda2",
                           },
                       }
                   },

                   new Ad()
                   {
                       Title = "Кученца Белгийска овчарка",
                        CategoryId = 2,
                       Location = "град Елин Пелин, област София",
                       Price = 330,
                       Description = "Продавам кученца белгийска овчарка с много добро родословие и с поставени всички необходими ваксини",
                       AddedByUserId = "846b3940-e6e8-46cb-b1c5-31476226abcf",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011010_big.jpg",
                               Extension = "jpg",
                               AdId = 6,
                               AddedByUserId = "846b3940-e6e8-46cb-b1c5-31476226abcf",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/n/nettisdogs/7226759_121011011_big.jpg",
                               Extension = "jpg",
                               AdId = 6,
                               AddedByUserId = "846b3940-e6e8-46cb-b1c5-31476226abcf",
                           },
                       }
                   },

                    new Ad()
                   {
                       Title = "Чистокръвна немска овчарка с три ваксини",
                        CategoryId = 2,
                       Location = "град Ямбол, област Ямбол",
                       Price = 300,
                       Description = "Момиче на 3 месеца и половина напълно самостиятвлна здрава, игрива енергична обезпаразитена вътрешно и външно с три ваксини и медецински паспорт.",
                       AddedByUserId = "946ad8e4-2e2f-4bbc-ab07-7444b0a7b838",
                        Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/p/pep_inoo/8334548_120672013_big.jpg",
                               Extension = "jpg",
                               AdId = 7,
                               AddedByUserId = "946ad8e4-2e2f-4bbc-ab07-7444b0a7b838",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/p/pep_inoo/8334548_120672015_big.jpg",
                               Extension = "jpg",
                               AdId = 7,
                               AddedByUserId = "946ad8e4-2e2f-4bbc-ab07-7444b0a7b838",
                           },
                       }
                   },

                     new Ad()
                   {
                       Title = "Продавам прекрасни малки самоеди.",
                        CategoryId = 2,
                       Location = "село Костиево, област Пловдив",
                       Price = 600,
                       Description = "Прекрасни малки самоеди се родиха на 22.09.22. Има 2 женски с розовата и оранжевата панделка другите 5 са мъжки с другите цветове панделки. Съдбовна дата кученца на шампиони, майката и бащата са наши красиви и родословни родители, като бащата и дядото и бабата са носители на първите места в киноложките изложби с много медали и купи. Кученцата са вътрешно и външно обезпаразитени и захранени с първокласна гранула. На 45тия ден ще бъдат ваксинирани и ще им издадем здравни книжки след което ще могат да зарадват своите нови стопани. Повярвайте те ще внесат в дома ви много любов и топлина.",
                       AddedByUserId = "9f69b2bc-8a36-4fe9-906a-d259ab1e2103",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038234_big.jpg",
                               Extension = "jpg",
                               AdId = 8,
                               AddedByUserId = "9f69b2bc-8a36-4fe9-906a-d259ab1e2103",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038246_big.jpg",
                               Extension = "jpg",
                               AdId = 8,
                               AddedByUserId = "9f69b2bc-8a36-4fe9-906a-d259ab1e2103",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/m/mima8383/8391142_121038277_big.jpg",
                               Extension = "jpg",
                               AdId = 8,
                               AddedByUserId = "9f69b2bc-8a36-4fe9-906a-d259ab1e2103",
                           },
                       }
                   },

                      new Ad()
                   {
                       Title = "Продавам мини пинчери",
                        CategoryId = 2,
                       Location = "град Ямбол, област Ямбол",
                       Price = 200,
                       Description = "Продавам 2 момчета и 2 момичета, бебета родени на 27.09.22. Едно кафяво момиче и едно черно. Момчетата са 2 кафяви. Обезпаразитени са. Хранят се и с гранула. Намират се в гр. Пазарджик.\r\nНе отговарям, на чат. Ако някой се интересува нека да се обади на посоченият телефон",
                       AddedByUserId = "946ad8e4-2e2f-4bbc-ab07-7444b0a7b838",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133817_big.jpg",
                               Extension = "jpg",
                               AdId = 9,
                               AddedByUserId = "946ad8e4-2e2f-4bbc-ab07-7444b0a7b838",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133819_big.jpg",
                               Extension = "jpg",
                               AdId = 9,
                               AddedByUserId = "946ad8e4-2e2f-4bbc-ab07-7444b0a7b838",
                           },
                       }
                   },

                      new Ad()
                   {
                       Title = "Продавам малки котета Британки",
                       CategoryId = 1,
                       Location = "град Варна, област Варна",
                       Price = 500,
                       Description = "Малки котета Британки, късокосмести. Момчета и момичета.",
                       AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/bilqna123/8405123_121133817_big.jpg",
                               Extension = "jpg",
                               AdId = 10,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/o/ovanezov/8186703_120850725_big.jpg",
                               Extension = "jpg",
                               AdId = 10,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/o/ovanezov/8186703_120850726_big.jpg",
                               Extension = "jpg",
                               AdId = 10,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },
                       }
                   },

                       new Ad()
                   {
                       Title = "Продавам британски късокосмести котета - две женски",
                       CategoryId = 1,
                       Location = "град Варна, област Варна",
                       Price = 400,
                       Description = "Котетата са две женски - родени са на 29.08.2022г., вече изцяло захранени с висококачествена храна (паучове + твърда), с изградени хигиенни навици. Много сладки и игриви!. Майка е много кротка! Бащата и майката са с чисти расови белези (може да ги видите на последните сникки)! за повече инфо, моля на телефона!",
                       AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_121054586_big.jpg",
                               Extension = "jpg",
                               AdId = 11,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_120869479_big.jpg",
                               Extension = "jpg",
                               AdId = 11,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/l/lucky_toshko/8366691_120869476_big.jpg",
                               Extension = "jpg",
                               AdId = 11,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },
                       }
                   },

                        new Ad()
                   {
                       Title = "Продавам Бял Екзот - Персийка",
                       CategoryId = 1,
                       Location = "град Варна, област Варна",
                       Price = 850,
                       Description = "Бяло, екзотично късокосместо коте, момиче, с родословие. Нашите котки са закупени от най-добрите развъдници в света. Те са международни шампиони на много котешки организации. Нямат генетични заболявания, защото имаме направени изследвания от сертифицирана намска лабораория и издадени сертефикати за това. На последните две снимки са награди на родителите.Възможна доставка в страната. Лиценз №150 от 08.04.2019г. Професионален и лицензиран селекционер, с висок стандарт на грижа, поддръжка, груминг, състезателна дейност и хранене на персийски и екзотични",
                       AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                        Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/balkanavista/8285098_120866724_big.jpg",
                               Extension = "jpg",
                               AdId = 12,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/b/balkanavista/8285098_120866725_big.jpg",
                               Extension = "jpg",
                               AdId = 12,
                               AddedByUserId = "afce9a24-c8e2-422e-a7cb-ea9690ee3e2b",
                           },
                       }
                   },

                         new Ad()
                   {
                       Title = "Чистокръвни Британски котенца",
                       CategoryId = 1,
                       Location = "град Пазарджик, област Пазарджик",
                       Price = 500,
                       Description = "Предлагам чистокръвни Британски късокосмести мъжки и женски котенца ( British shorthair) от елитни родители, с доказан произход. В момента на вземане котета ще са социализирани, обезпаразитени, с проведен обстоен ветеринаромедицински преглед гарантиращ безупречното им здраве, научени на котешка тоалетна, самостоятелно се храни със суха храна премиум класа, и е научено да си остри ноктите върху специални уреди предназначени за това. Добре се разбират с деца и други домашни любимци, големи гальовници, с добър нрав. Цена 500 и 600 лв. При покупка ще получите съвети за правилното хранене и отглеждане на вашия домашен любимец.",
                       AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/k/krot/7524850_120975338_big.jpg",
                               Extension = "jpg",
                               AdId = 13,
                               AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/k/krot/7524850_120924476_big.jpg",
                               Extension = "jpg",
                               AdId = 13,
                               AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                           },
                       }
                   },

                          new Ad()
                   {
                       Title = "Персийско късокосместо женско коте",
                       CategoryId = 1,
                       Location = "град Пазарджик, област Пазарджик",
                       Price = 200,
                       Description = "Персийско късокосместо женско коте на три месеца. Котето е с изградени хигиенни навици и е захранено с висококачествени храни. Обезпаразитено. За повече информация на посочения телефон!",
                       AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                       Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/t/t1gt/8405403_121135746_big.jpg",
                               Extension = "jpg",
                               AdId = 14,
                               AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                           },
                       }
                   },

                               new Ad()
                   {
                       Title = "Шотландско клепоухо коте на 2 месеца",
                       CategoryId = 1,
                       Location = "град Пазарджик, област Пазарджик",
                       Price = 400,
                       Description = "Разкошни шотландски клепоухи сладури,\r\nТъмното таби мъжко на 2 месеца и половина. 400 лв.\r\nСини и лилави - 600 лв.\r\nКотетата са обезпаразитени /вътрешно и външно/, захранени с висококачествена гранулирана храна и с изградени хигиенни навици, приучени да острят ноктите си на драскалка. Породата е символ на спокойствие, достойнство, самообладание, чар, стил, аристократичност и домашен уют. Притежават мил, благ, уравновесен и гальовно ориентиран характер. Те са умни и чистоплътни животни. Безпроблемно съжителстват с хора и други домашни любимци. Дружелюбни и ласкави. Лесно се привързват и обичат всички членове на семейството.",
                       AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                        Images =
                       {
                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043539_big.jpg",
                               Extension = "jpg",
                               AdId = 15,
                               AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043533_big.jpg",
                               Extension = "jpg",
                               AdId = 15,
                               AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                           },

                           new Image()
                           {
                               RemoteImageUrl = "https://www.alo.bg/user_files/s/stenli76/8043919_119043537_big.jpg",
                               Extension = "jpg",
                               AdId = 15,
                               AddedByUserId = "df9adf49-d858-42ca-ba8e-b08452005abb",
                           },
                       }
                   },
               };

                await dbContext.Ads.AddRangeAsync(ads);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
