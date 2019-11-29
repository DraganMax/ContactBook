// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ContactBook.DependencyResolution {
    using AutoMapper;
    using ContactBook.App_Start;
    using ContactBook.core.Services;
    using ContactBookService.data;
    using ContactBook.services;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.ConnectImplementationsToTypesClosing(typeof(IEntityService<>));
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<IContactDbContext>().Use<ContactDbContext>().Transient();
            For<IDbService>().Use<DbService>();
            For(typeof(IEntityService<>)).Use(typeof(EntityService<>));
            For<IContactService>().Use<ContactService>();
            For<IPhoneService>().Use<PhoneService>();
            For<IAdressService>().Use<AdressService>();
            For<IEmailService>().Use<EmailService>();

            var mapper = AutoMapperConfig.GetMapper();
            For<IMapper>().Use(mapper).Singleton();
        }

        #endregion
    }
}