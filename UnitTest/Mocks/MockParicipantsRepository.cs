using Moq;
using OnelityAssigment.DTO;
using OnelityAssigment.Models;
using OnelityAssigment.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnelityAssigmentUnitTest.RepositoryTest
{
    public class MockParicipantsRepository: Mock<IParticipantRepository>
    {
        public void ToHaveAdded(Participant data)
        {
            this.Verify(d => d.CreateAsync(It.Is<Participant>(
                    entity => entity.GetType() == data.GetType() &&
                    AutoCompare.Comparer.Compare<Participant>(entity, data).Count == 0)),Times.Once);
        }

        public void ToHaveEnquiredToFindAll()
        {
            this.Verify(d => d.FindAll(), Times.Once);
        }

        public void ToHaveEnquiredToFindAllByConference(int conferenceId)
        {
            this.Verify(d => d.AllByConferenceId(conferenceId), Times.Once);
        }

        public void ToHaveDeleted(int id)
        {
            this.Verify(d => d.DeleteAsync(id), Times.Once);
        }

        public void ToHaveUpdated(Participant participant)
        {
            this.Verify(d => d.Update(It.Is<Participant>(
                entity => entity.GetType() == participant.GetType() &&
                AutoCompare.Comparer.Compare<Participant>(entity, participant).Count == 0)), Times.Once);
        }

        public void ShouldFindByContitionAndReturn(Participant participant)
        {
            this.Setup(d => d.FindById(It.IsAny<int>())).ReturnsAsync(participant);
        }

        public void ShouldReturnList()
        {
            List<Participant> participants = new List<Participant>();
            Participant participant = new Participant
            {
                ConferenceId = 1,
                FirstName = "Test",
                LastName = "Tetst",
                Id = 1,
                Email = "tests@test.com"
            };
            participants.Add(participant);

            this.Setup(d => d.FindAll()).ReturnsAsync(participants);
        }

        public void ShouldReturnListWith(int conferenceId)
        {
            List<Participant> participants = new List<Participant>();
            Participant participant = new Participant
            {
                ConferenceId = conferenceId,
                FirstName = "Test",
                LastName = "Tetst",
                Id = 1,
                Email = "tests@test.com"
            };
            participants.Add(participant);

            this.Setup(d => d.AllByConferenceId(conferenceId)).ReturnsAsync(participants);
        }
    }
}
