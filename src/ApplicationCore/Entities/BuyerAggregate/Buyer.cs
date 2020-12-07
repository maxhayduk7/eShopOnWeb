﻿using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Exceptions;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();
        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        private List<BuyerAddress> _buyerAddresses = new List<BuyerAddress>();
        public IEnumerable<BuyerAddress> BuyerAddresses => _buyerAddresses.AsReadOnly();

        private Buyer()
        {
            // required by EF
        }

        public Buyer(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }

        public void AddAddress(Address address)
        {
            if(_buyerAddresses.Any(currentAddress => currentAddress.Address == address))
            {
                throw new DuplicateAddressException();
            }
            var newAddress = new BuyerAddress(this.Id);
            newAddress.UpdateAddress(address);

            _buyerAddresses.Add(newAddress);
        }
    }
}
