using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Models;
using CommonLibrary.Repositories.Implementations;
using Microsoft.Extensions.Caching.Distributed;

namespace CommonLibrary.Repositories
{
    public class DataManager
    {
	    private CustomersRepository _customersRepository;
	    private EntitiesRepository _entitiesRepository;

		private IDistributedCache _distributedCache;

		public DataManager(CustomersRepository customersRepository, EntitiesRepository entitiesRepository, IDistributedCache distributedCache)
		{
			_customersRepository = customersRepository;
			_entitiesRepository = entitiesRepository;
			_distributedCache = distributedCache;
		}

	    #region Customers


	    public List<Customer> GetAllCustomers()
	    {
		    return _customersRepository.GetAll().Result;
	    }

	    public Customer GetCustomerById(string customerId)
	    {
		    return _customersRepository.GetById(customerId).Result;
	    }

	    public async Task CreateCustomer(Customer newCustomer)
	    {
		    await _customersRepository.Create(newCustomer);
	    }

	    public void UpdateOrCreateCustomer(Customer customer)
	    {
		    _customersRepository.Replace(customer);
	    }

	    public bool RemoveCustomer(string customerId)
	    {
		    return _customersRepository.Remove(customerId).Result;
	    }

	    public bool CustomerExists(string customerId)
	    {
		    return GetCustomerById(customerId) != null;
	    }

		#endregion Customers

		#region Entities


		public List<Entity> GetAllEntities()
	    {
		    return _entitiesRepository.GetAll().Result;
	    }

	    public Entity GetEntityById(string entityId)
	    {
		    return _entitiesRepository.GetById(entityId).Result;
	    }

	    public async Task CreateEntity(Entity newEntity)
	    {
		    await _entitiesRepository.Create(newEntity);
	    }

	    public void UpdateOrCreateEntity(Entity entity)
	    {
		    _entitiesRepository.Replace(entity);
	    }

	    public bool RemoveEntity(string entityId)
	    {
		    return _entitiesRepository.Remove(entityId).Result;
	    }

	    public bool EntityrExists(string entityId)
	    {
		    return GetEntityById(entityId) != null;
	    }

	    #endregion Entities
	}
}
