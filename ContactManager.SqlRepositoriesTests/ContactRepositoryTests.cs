﻿using System;
using ContactManager.SqlRepositories;
using System.Threading.Tasks;
using CCH.BCL.Data;
using Xunit;

namespace ContactManager.SqlRepositoriesTests {

    public class ContactRepositoryTests {

        [Fact]
        public void XunitIsRunning() {
            // no code needed
        }

        //[Fact]
        //public async Task Repo_GetContacts_ReturnsList() {

        //    var sut = BuildContactRepository();

        //    var results = await sut.GetContactsAsync(0, 20);

        //    Assert.NotNull(results);

        //}

        //[Fact]
        //public async Task Repo_InsertContact_UpdatesID() {

        //    var sut = BuildContactRepository();

        //    var result = await sut.InsertContactAsync(new DomainModel.Models.Contact() {
        //        FirstName = "Brian",
        //        LastName = "White"
        //    });

        //    Assert.NotEqual(0, result.ContactID);

        //}

        //private ContactRepository BuildContactRepository() {

        //    string connectionString = "server = . ; database = ContactManager ; user id = sa ; pwd = Afpftcb1td";

        //    var sqlClient = new CCH.BCL.Data.SQLClient(connectionString);

        //    var sut = new ContactRepository(sqlClient);

        //    return sut;

        //}

    }

}
