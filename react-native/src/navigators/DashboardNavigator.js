import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import DashboardScreen from '../screens/Dashboard/DashboardScreen';
import MenuIcon from '../components/MenuIcon/MenuIcon';
import { LocalizationContext } from '../contexts/LocalizationContext';

const Stack = createStackNavigator();

export default function DashboardStackNavigator() {
  const { t } = React.useContext(LocalizationContext);

  return (
    <Stack.Navigator initialRouteName="Dashboard">
      <Stack.Screen
        name="Dashboard"
        component={DashboardScreen}
        options={({ navigation }) => ({
          headerLeft: () => <MenuIcon onPress={() => navigation.openDrawer()} />,
          title: t('::Menu:Dashboard'),
        })}
      />
    </Stack.Navigator>
  );
}
