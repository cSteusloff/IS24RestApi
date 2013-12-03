﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IS24RestApi.Tests
{
    public class ContactTests: TestBase
    {
        public ContactTests()
            : base(@"http://rest.sandbox-immobilienscout24.de/restapi/api/offer/v1.0")
        { }

        [Fact]
        public async Task Contact_Get_RequestsCorrectResource()
        {
            Http.RespondWith(m =>
            {
                Assert.Equal("GET", m);
                Assert.Equal("http://rest.sandbox-immobilienscout24.de/restapi/api/offer/v1.0/user/me/contact/4711", Http.Url.ToString());
                return new RealtorContactDetails { id = 4711, idSpecified = true };
            });

            var contact = await Client.Contacts.GetAsync("4711");
        }

        [Fact]
        public async Task Contact_Get_RequestsCorrectExternalIdPrefix()
        {
            Http.RespondWith(m =>
            {
                Assert.True(Http.Url.AbsoluteUri.EndsWith("/ext-Hans%20Meiser"));
                return new RealtorContactDetails { externalId = "Hans Meiser", id = 4711, idSpecified = true };
            });

            var contact = await Client.Contacts.GetAsync("Hans Meiser", isExternal: true);
        }

        [Fact]
        public async Task Contact_Get_ResourceDoesNotExist_ThrowsIS24Exception()
        {
            Http.RespondWith(m =>
            {
                return new HttpStubResponse { StatusCode = HttpStatusCode.NotFound, ResponseObject = new messages() };
            });

            await AssertEx.ThrowsAsync<IS24Exception>(async () =>
            {
                var contact = await Client.Contacts.GetAsync("test");
            });
        }

        [Fact]
        public async Task Contact_Get_CanDeserializeResponse()
        {
            Http.RespondWith(m =>
            {
                return new RealtorContactDetails { id = 4711, idSpecified = true };
            });

            var contact = await Client.Contacts.GetAsync("4711");

            Assert.IsType<RealtorContactDetails>(contact);
            Assert.Equal(4711, contact.id);
        }

        [Fact]
        public async Task Contact_Create_RequestsCorrectResource()
        {
            Http.RespondWith(m =>
            {
                Assert.Equal("POST", m);
                Assert.Equal("http://rest.sandbox-immobilienscout24.de/restapi/api/offer/v1.0/user/me/contact", Http.Url.ToString());
                return new messages { message = new[] { new Message { messageCode = MessageCode.MESSAGE_RESOURCE_CREATED, message = "Contact with id [4711] has been created." } } };
            });

            var contact = new RealtorContactDetails { lastname = "Meiser" };

            await Client.Contacts.CreateAsync(contact);
        }

        [Fact]
        public async Task Contact_Create_CallSucceeds_RealEstateObjectHasNewId()
        {
            Http.RespondWith(m =>
            {
                return new messages { message = new[] { new Message { messageCode = MessageCode.MESSAGE_RESOURCE_CREATED, message = "Contact with id [4711] has been created." } } };
            });

            var contact = new RealtorContactDetails { lastname = "Meiser" };

            await Client.Contacts.CreateAsync(contact);

            Assert.Equal(4711, contact.id);
        }

        [Fact]
        public async Task Contact_Create_PostsRealtorObject()
        {
            Http.RespondWith(m =>
            {
                var c = new BaseXmlDeserializer().Deserialize<RealtorContactDetails>(new RestResponse { Content = Http.RequestBody });
                Assert.IsType<RealtorContactDetails>(c);
                Assert.Equal("Meiser", c.lastname);
                return new messages { message = new[] { new Message { messageCode = MessageCode.MESSAGE_RESOURCE_CREATED, message = "Contact with id [4711] has been created." } } };
            });

            var contact = new RealtorContactDetails { lastname = "Meiser" };

            await Client.Contacts.CreateAsync(contact);
        }

        [Fact]
        public async Task Contact_Create_ErrorOccurs_ThrowsIS24Exception()
        {
            Http.RespondWith(m =>
            {
                return new HttpStubResponse { StatusCode = HttpStatusCode.PreconditionFailed, ResponseObject = new messages() };
            });

            await AssertEx.ThrowsAsync<IS24Exception>(async () =>
            {
                await Client.Contacts.CreateAsync(new RealtorContactDetails());
            });
        }

        [Fact]
        public async Task Contact_Update_RequestsCorrectResource()
        {
            Http.RespondWith(m =>
            {
                Assert.Equal("PUT", m);
                Assert.Equal("http://rest.sandbox-immobilienscout24.de/restapi/api/offer/v1.0/user/me/contact/4711", Http.Url.ToString());
                return new messages { message = new[] { new Message { messageCode = MessageCode.MESSAGE_RESOURCE_UPDATED, message = "" } } };
            });

            var contact = new RealtorContactDetails { id = 4711, idSpecified = true };

            await Client.Contacts.UpdateAsync(contact);
        }

        [Fact]
        public async Task Contact_Create_CallSucceeds_NoExceptionThrown()
        {
            Http.RespondWith(m =>
            {
                return new messages { message = new[] { new Message { messageCode = MessageCode.MESSAGE_RESOURCE_UPDATED, message = "" } } };
            });

            var contact = new RealtorContactDetails { id = 4711, idSpecified = true };

            await Client.Contacts.UpdateAsync(contact);
        }

        [Fact]
        public async Task Contact_Update_PostsRealEstateObject()
        {
            Http.RespondWith(m =>
            {
                var c = new BaseXmlDeserializer().Deserialize<RealtorContactDetails>(new RestResponse { Content = Http.RequestBody });
                Assert.IsType<RealtorContactDetails>(c);
                Assert.Equal(4711, c.id);
                return new messages { message = new[] { new Message { messageCode = MessageCode.MESSAGE_RESOURCE_UPDATED, message = "" } } };
            });

            var contact = new RealtorContactDetails { id = 4711, idSpecified = true };

            await Client.Contacts.UpdateAsync(contact);
        }

        [Fact]
        public async Task Contact_Update_ErrorOccurs_ThrowsIS24Exception()
        {
            Http.RespondWith(m =>
            {
                return new HttpStubResponse { StatusCode = HttpStatusCode.PreconditionFailed, ResponseObject = new messages() };
            });

            await AssertEx.ThrowsAsync<IS24Exception>(async () =>
            {
                await Client.Contacts.UpdateAsync(new RealtorContactDetails());
            });
        }

        [Fact]
        public async Task Contact_GetAll_RequestsCorrectResource()
        {
            Http.RespondWith(m =>
            {
                Assert.Equal("GET", m);
                Assert.Equal("http://rest.sandbox-immobilienscout24.de/restapi/api/offer/v1.0/user/me/contact", Http.Url.ToString());
                return new realtorContactDetailsList { realtorContactDetails = new RealtorContactDetails[] { } };
            });

            var cs = await Client.Contacts.GetAsync();
        }

        [Fact]
        public async Task Contact_GetAll_CanDeserializeResponse()
        {
            Http.RespondWith(m =>
            {
                return new realtorContactDetailsList
                {
                    realtorContactDetails = new RealtorContactDetails[] { 
                        new RealtorContactDetails { id = 4711, idSpecified = true },
                        new RealtorContactDetails { id = 4712, idSpecified = true },
                    }
                };
            });

            var cs = (await Client.Contacts.GetAsync()).ToList();

            Assert.Equal(2, cs.Count);
            Assert.Equal(4711, cs[0].id);
            Assert.Equal(4712, cs[1].id);
        }
    }
}
