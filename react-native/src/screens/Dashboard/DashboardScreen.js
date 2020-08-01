import { Container, Content } from 'native-base';
import React from 'react';
import HostDashboard from './HostDashboard';
import TenantDashboard from './TenantDashboard';
import { usePermission } from '../../hooks/UsePermission';

function DashboardScreen() {
  const host = usePermission('MonkBlog.Dashboard.Host');
  return (
    <Container>
      <Content px20>{host ? <HostDashboard /> : <TenantDashboard />}</Content>
    </Container>
  );
}

export default DashboardScreen;
