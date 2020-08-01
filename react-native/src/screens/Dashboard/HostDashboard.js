import React from 'react';
import ErrorRateWidget from './ErrorRateWidget';
import EditionUsageWidget from './EditionUsageWidget';
import { usePermission } from '../../hooks/UsePermission';
import { toLocalISOString } from '../../utils/DateExtensions';

const now = new Date();
const filter = {
  endDate: toLocalISOString(now),
  get startDate() {
    return toLocalISOString(new Date(now.getFullYear() - 1, 0, 1));
  },
};

function HostDashboard() {
  const errorRatePermission = usePermission('AuditLogging.AuditLogs');
  const editionUsagePermission = usePermission('Saas.Tenants');

  return (
    <>
      {errorRatePermission && <ErrorRateWidget {...filter} />}
      {editionUsagePermission && <EditionUsageWidget {...filter} />}
    </>
  );
}

export default HostDashboard;
