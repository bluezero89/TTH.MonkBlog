import { useFocusEffect } from '@react-navigation/native';
import i18n from 'i18n-js';
import { Card, CardItem, Text } from 'native-base';
import PropTypes from 'prop-types';
import React, { useCallback, useState } from 'react';
import { Dimensions } from 'react-native';
import { PieChart } from 'react-native-chart-kit';
import { getUsageStatistics } from '../../api/SaasAPI';
import { getRandomColors } from '../../utils/RandomColor';

function EditionUsageWidget({ startDate, endDate }) {
  const [data, setData] = useState([]);

  const fetch = () => {
    getUsageStatistics({ startDate, endDate }).then(res => {
      const keys = Object.keys(res.data);
      const colors = getRandomColors(keys.length);
      setData(
        keys.map((key, index) => ({
          value: res.data[key],
          name: key,
          color: colors[index],
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
          <Text>{i18n.t('Saas::EditionUsageStatistics')}</Text>
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

EditionUsageWidget.propTypes = {
  startDate: PropTypes.string.isRequired,
  endDate: PropTypes.string.isRequired,
};

export default EditionUsageWidget;
