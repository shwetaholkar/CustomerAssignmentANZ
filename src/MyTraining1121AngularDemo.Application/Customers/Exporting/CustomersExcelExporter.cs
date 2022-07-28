using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using MyTraining1121AngularDemo.DataExporting.Excel.NPOI;
using MyTraining1121AngularDemo.Customers.Dtos;
using MyTraining1121AngularDemo.Dto;
using MyTraining1121AngularDemo.Storage;

namespace MyTraining1121AngularDemo.Customers.Exporting
{
    public class CustomersExcelExporter : NpoiExcelExporterBase, ICustomersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CustomersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCustomerForViewDto> customers)
        {
            return CreateExcelPackage(
                "Customers.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Customers"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Email"),
                        L("Address"),
                        L("RegistrationDate")
                        );

                    AddObjects(
                        sheet, customers,
                        _ => _.Customer.Name,
                        _ => _.Customer.Email,
                        _ => _.Customer.Address,
                        _ => _timeZoneConverter.Convert(_.Customer.RegistrationDate, _abpSession.TenantId, _abpSession.GetUserId())
                        );

                    for (var i = 1; i <= customers.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[4], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(4);
                });
        }
    }
}