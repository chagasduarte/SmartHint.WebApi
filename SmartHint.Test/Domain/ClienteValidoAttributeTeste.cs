using Moq;
using SmartHint.Domain.Models;
using SmartHint.Domain.Models.Validations.Handles;
using System.ComponentModel.DataAnnotations;

namespace SmartHint.Domain.Validations.Tests
{
    public class ClienteValidoAttributeTests
    {
        private readonly ClienteValidoAttribute _atributo;
        private readonly Mock<EmailInUseHandler> _emailInUseHandlerMock;
        private readonly Mock<CpfCnjInUseHandler> _cpfCnjInUseHandlerMock;
        private readonly Mock<CamposPessoaFisicaHandler> _camposPessoaFisicaHandlerMock;
        private readonly Mock<InscricaoEstadualObrigatorioPjHandler> _inscricaoEstadualPjHandlerMock;
        private readonly Mock<InscricaoEstadualObrigatorioPfHandler> _inscricaoEstadualPfHandlerMock;
        private readonly Mock<InscricaoEstadualInUseHandler> _inscricaoEstadualInUseMock;
        private readonly Mock<ValidaTelefoneHandler> _telefoneMock;
        private readonly Mock<ValidaCpfCnpjNumericoHandler> _cpfCnjValidoMock;
        private readonly Mock<InscricaoEstadualNumericaHandler> _inscricaoEstadualNumericaMock;

        public ClienteValidoAttributeTests()
        {
            _atributo = new ClienteValidoAttribute();

            _emailInUseHandlerMock = new Mock<EmailInUseHandler>();
            _cpfCnjInUseHandlerMock = new Mock<CpfCnjInUseHandler>();
            _camposPessoaFisicaHandlerMock = new Mock<CamposPessoaFisicaHandler>();
            _inscricaoEstadualPjHandlerMock = new Mock<InscricaoEstadualObrigatorioPjHandler>();
            _inscricaoEstadualPfHandlerMock = new Mock<InscricaoEstadualObrigatorioPfHandler>();
            _inscricaoEstadualInUseMock = new Mock<InscricaoEstadualInUseHandler>();
            _telefoneMock = new Mock<ValidaTelefoneHandler>();
            _cpfCnjValidoMock = new Mock<ValidaCpfCnpjNumericoHandler>();
            _inscricaoEstadualNumericaMock = new Mock<InscricaoEstadualNumericaHandler>();

            // Setup the handlers with mocks if necessary
        }

        [Fact]
        public void IsValid_ShouldReturnSuccess_WhenClienteIsValid()
        {
            // Arrange
            var cliente = new Cliente { Id = 1 }; // Set up a valid client
            var validationContext = new ValidationContext(cliente);

            // Assume that handlers are set up correctly and validate successfully
            _emailInUseHandlerMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _cpfCnjInUseHandlerMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _cpfCnjValidoMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _camposPessoaFisicaHandlerMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _inscricaoEstadualPjHandlerMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _inscricaoEstadualPfHandlerMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _inscricaoEstadualInUseMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _inscricaoEstadualNumericaMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());
            _telefoneMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());

            // Act
            var result = _atributo.GetValidationResult(cliente, validationContext);

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void IsValid_ShouldReturnError_WhenClienteIsInvalid()
        {
            // Arrange
            var cliente = new Cliente { Id = 0 }; // Set up an invalid client
            var validationContext = new ValidationContext(cliente);

            // Setup handlers to return an error
            _emailInUseHandlerMock.Setup(x => x.Handle(It.IsAny<Cliente>())).Returns(new ValidationModel());

            // Act
            var result = _atributo.GetValidationResult(cliente, validationContext);

            // Assert
            Assert.NotEqual(ValidationResult.Success, result);
            Assert.Equal("Email in use", result.ErrorMessage);
        }
    }
}
