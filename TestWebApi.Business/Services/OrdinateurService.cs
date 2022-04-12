﻿using TestWebApi.Business.Interfacage.Services;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.Business.Services
{
    public class OrdinateurService : IOrdinateurService
    {
        private readonly IOrdinateurRepository _ordinateurRepository;

        public OrdinateurService(IOrdinateurRepository ordinateurRepository)
        {
            _ordinateurRepository = ordinateurRepository;
        }

        public async Task AddOrdinateur(OrdinateurDto ordinateur)
        {
            Ordinateur entity = new Ordinateur();
            entity = OrdinateurDto.Populate(ordinateur, entity);
            await _ordinateurRepository.Add(entity);
        }

        public async Task<IEnumerable<OrdinateurDto>> GetAllOrdinateurs() => await _ordinateurRepository.GetAllOrdinateurs();

        public async Task<OrdinateurDto> GetOrdinateurById(Guid id) => await _ordinateurRepository.GetOrdinateurById(id);
    }
}
