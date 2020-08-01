import { useFocusEffect } from '@react-navigation/native';
import i18n from 'i18n-js';
import { Card, CardItem, Text } from 'native-base';
import PropTypes from 'prop-types';
import React, { useCallback, useState } from 'react';
import { Dimensions } from 'react-native';
import { PieChart } from 'react-native-chart-kit';
import { getErrorRateStatistics } from '../../api/AuditLoggingAPI';
import { activeTheme } from '../../theme/variables';

function ErrorRateWidget({ startDate, endDate }) {
  const [data, setData] = useState([]);

  const fetch = () => {
    getErrorRateStatistics({ startDate, endDate }).then(res => {
      const keys = Object.keys(res.data);
      setData(
        keys.map((key, index) => ({
          value: res.data[key],
          name: key,
          color: index === 0 ? activeTheme.brandDanger : activeTheme.brandSuccess,
        })),
      );
    });
  };

  useFocusEffect(
    useCallback(() => {
      fetch();
    }, []),
  );

  return (
    <>
      <Card>
        <CardItem header>
          <Text>{i18n.t('AbpAuditLogging::ErrorRateInLogs')}</Text>
        </CardItem>
        {data.length ? (
          <PieChart
            data={data}
            width={Dimensions.get('window').width}
            height={150}
            chartConfig={{
              color: (opacity = 1) => `rgba(0, 0, 0, ${opacity})`,
            }}
            accessor="value"
            backgroundColor="transparent"
            absolute
            hasLegend
          />
        ) : null}
      </Card>
    </>
  );
}

ErrorRateWidget.propTypes = {
  startDate: PropTypes.string.isRequired,
  endDate: PropTypes.string.isRequired,
};

export default ErrorRateWidget;
