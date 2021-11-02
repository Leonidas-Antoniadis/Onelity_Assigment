using OnelityAssigment.DTO;
using OnelityAssigment.Models;
using OnelityAssigment.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnelityAssigment.Services
{
    public class ParticipantService
    {
        private readonly IParticipantRepository _repository;

        public ParticipantService(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Participant participant)
        {
            await _repository.CreateAsync(participant);
        }

        public async Task Delete(int participantId)
        {
            await _repository.DeleteAsync(participantId);
        }

        public async Task Update(UpdateParticipant updateParticipant)
        {
            Participant participant = await _repository.FindById(updateParticipant.Id);

            if(participant == default)
            {
                throw new Exception("Could not find participant");
            }
            
            if(updateParticipant.FirstName != default)
            {
                participant.FirstName = updateParticipant.FirstName;
            }

            if (updateParticipant.LastName != default)
            {
                participant.LastName = updateParticipant.LastName;
            }

            if (updateParticipant.Email != default)
            {
                participant.Email = updateParticipant.Email;
            }

            if (updateParticipant.ConferenceId != default)
            {
                participant.ConferenceId = (int)updateParticipant.ConferenceId;
            }

            await _repository.Update(participant);
        }

        public Task<List<Participant>> AllByConference(int conferenceId)
        {
            return _repository.AllByConferenceId(conferenceId);
        }

        public async Task<List<Participant>> All()
        {
            return await _repository.FindAll();
        }
    }
}
