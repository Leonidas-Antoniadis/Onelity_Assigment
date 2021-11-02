using OnelityAssigment.DTO;
using OnelityAssigment.Models;
using OnelityAssigment.Repository;
using OnelityAssigment.Services;
using OnelityAssigmentUnitTest.RepositoryTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OnelityAssigmentUnitTest
{
    public class ParticipantsServiceTest
    {       
        private readonly MockParicipantsRepository _mockRepository;
        private readonly ParticipantService _service;
        public ParticipantsServiceTest()
        {
            _mockRepository = new MockParicipantsRepository();

            IParticipantRepository repository = _mockRepository.Object;

            _service = new ParticipantService(repository);
        }

        [Fact]
        public async Task AddTest()
        {
            var newParticipant = new Participant
            {
                ConferenceId = 1,
                Email = "Add@test.com",
                FirstName = "Test",
                LastName = "MyTest",
                 
            };

            await _service.Add(newParticipant);

            _mockRepository.ToHaveAdded(newParticipant);
        }

        [Fact]
        public async Task AllTest()
        {
            _mockRepository.ShouldReturnList();

            var result = await _service.All();

            _mockRepository.ToHaveEnquiredToFindAll();
            Assert.IsType<List<Participant>>(result);
        }

        [Fact]
        public async Task AllByConferenceTest()
        {
            int conferenceId = 2;
            _mockRepository.ShouldReturnListWith(conferenceId);

            var result = await _service.AllByConference(conferenceId);

            _mockRepository.ToHaveEnquiredToFindAllByConference(conferenceId);
            Assert.IsType<List<Participant>>(result);
        }

        [Fact]
        public async Task DeleteTest()
        {
            int id = 2;

            await _service.Delete(id);

            _mockRepository.ToHaveDeleted(id);
        }

        [Fact]
        public async Task UpdateTest()
        {
            UpdateParticipant upatedParticipant = new UpdateParticipant
            {
                Id = 2,
                FirstName = "My new Test",
                LastName = "My Name"
            };
            var participant = new Participant
            {
                Id = 2,
                ConferenceId = 1,
                Email = "Add@test.com",
                FirstName = "My Test",
                LastName = "MyTest",

            };
            _mockRepository.ShouldFindByContitionAndReturn(participant);

            await _service.Update(upatedParticipant);

            _mockRepository.ToHaveUpdated(new Participant
            {
                Id = 2,
                FirstName = "My new Test",
                LastName = "My Name",
                Email = "Add@test.com",
                ConferenceId = 1
            });
        }

        [Fact]
        public async Task UpdateCouldNotFindParticipantTest()
        {
            UpdateParticipant upatedParticipant = new UpdateParticipant
            {
                Id = 2,
                FirstName = "My Test"
            };

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.Update(upatedParticipant));

            Assert.Contains("Could not find participant", ex.Message);
        }
    }
}